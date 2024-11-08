using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using PROG7312_municipality.Model;
using PROG7312_municipality.Repositories;

namespace PROG7312_municipality.View
{
    public partial class EventView : UserControl
    {
        private ObservableCollection<EventItem> _items;
        private ObservableCollection<EventItem> _filteredItems;
        private Dictionary<int, EventItem> _eventDictionary;
        private readonly EventRepository _repository;

        //Selection Option
        private HashSet<string> _itemTypes;
        private HashSet<string> _tags;

        public EventView()
        {
            InitializeComponent();
            _repository = new EventRepository();
            LoadData();
        
        }

        private void LoadData()
        {
            var eventList = _repository.GetEvents();
            _eventDictionary = new Dictionary<int, EventItem>();
            _itemTypes = new HashSet<string>();
            _tags = new HashSet<string>();

            foreach (var eventItem in eventList)
            {
                //populating the dictionary for retrieval by eventID
                _eventDictionary[eventItem.EventID] = eventItem;

                //populating the selection options into SETS
                _itemTypes.Add("All");
                _itemTypes.Add(eventItem.ItemType);
                _tags.Add("All");
                _tags.Add(eventItem.Tag);
            }

            // Original list of data
            _items = new ObservableCollection<EventItem>(eventList);
            // Copied list of data for filtering purposes
            _filteredItems = new ObservableCollection<EventItem>(_items);


            //populate list and selection box
            ItemsListBox.ItemsSource = _filteredItems;
            TagComboBox.ItemsSource = _itemTypes;
            ItemTypeComboBox.ItemsSource = _tags;


            // newest events first
            Sort("Date", ListSortDirection.Descending);


            //recommendation
            UpdateFilteredItemsAsync();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void TagComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ItemTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filter = FilterTextBox.Text.ToLower();
            var  selectedTag = ItemTypeComboBox.SelectedItem as string;
            var selectedItemType = TagComboBox.SelectedItem as string;

            _filteredItems.Clear();

            foreach (var item in _items)
            {
                bool matchesItemType = string.IsNullOrEmpty(selectedItemType) || selectedItemType == "All" || item.ItemType == selectedItemType;
                bool matchesTag = string.IsNullOrEmpty(selectedTag) || selectedTag == "All" || item.Tag == selectedTag;
                bool matchesText = item.Title.ToLower().Contains(filter) ||
                                   item.ItemType.ToLower().Contains(filter) ||
                                   (item.Tag != null && item.Tag.ToLower().Contains(filter));

                if (matchesItemType && matchesTag && matchesText)
                {
                    _filteredItems.Add(item);
                }
            }
        }




        private GridViewColumnHeader _lastHeaderClicked = null;
        private ListSortDirection _lastDirection = ListSortDirection.Ascending;

        private void ListViewColumnHeader_Click(object sender, MouseButtonEventArgs e)
        {
            DependencyObject clickedHeader = e.OriginalSource as DependencyObject;

            while (clickedHeader != null && !(clickedHeader is GridViewColumnHeader))
            {
                clickedHeader = VisualTreeHelper.GetParent(clickedHeader);
            }

            if (clickedHeader is GridViewColumnHeader headerClicked)
            {
                string header = headerClicked.Column.Header as string;
                //Console.WriteLine($"Column Header Pressed: {header}");

                ListSortDirection direction;

                if (headerClicked != _lastHeaderClicked)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    direction = _lastDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
                }

                if (!string.IsNullOrEmpty(header))
                {
                    Sort(header, direction);
                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(ItemsListBox.ItemsSource);

            dataView.SortDescriptions.Clear();

            string sortProperty;
            if (sortBy == "Date")
            {
                sortProperty = "EventDate";
            }
            else if (sortBy == "Title")
            {
                sortProperty = "Title";
            }
            else
            {
                sortProperty = sortBy;
            }

            SortDescription sd = new SortDescription(sortProperty, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();





            // Update _filteredItems with the sorted collection
            _filteredItems = new ObservableCollection<EventItem>(
                dataView.Cast<EventItem>()
            );

            // Update the ListBox's ItemsSource
            ItemsListBox.ItemsSource = _filteredItems;
        }


        private UserRepository userRepository = new UserRepository();
        private EventInteractionRepository eventInteractionRepository = new EventInteractionRepository();

        private async void ItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is EventItem selectedItem)
            {
                if (_eventDictionary.TryGetValue(selectedItem.EventID, out EventItem eventDetails))
                {
                    // Show custom message box with event details
                    var messageBox = new CustomMessageBox(eventDetails)
                    {
                        Owner = Window.GetWindow(this) // Sets location at window
                    };
                    messageBox.ShowDialog();




                    // Retrieve the user ID + Logging Event interaction
                    var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                    if (user != null)
                    {
                        await LogEventInteractionAsync(eventDetails.EventID, user.Id);
                    }
                }
            }
        }

        private async Task LogEventInteractionAsync(int eventId, Guid userId)
        {
            await eventInteractionRepository.SaveEventClickAsync(eventId, userId);
        }




        //////////////////////////////////////////////////
        // recommendation based on frequent event clicks
        //////////////////////////////////////////////////
        ///
        public int GetTrendiestEventId(List<EventClickModel> eventClickList)
        {
            var lastWeekClicks = eventClickList
                .Where(click => click.ClickTime >= DateTime.Now.AddDays(-7));

            var eventFrequency = lastWeekClicks
                .GroupBy(click => click.EventID)
                .Select(group => new { EventID = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            return eventFrequency?.EventID ?? -1; // Return -1 if no events found
        }

        public async Task UpdateFilteredItemsAsync()
        {
            var eventClickList = await eventInteractionRepository.GetClickedEventsAsync();
            int trendiestEventId = GetTrendiestEventId(eventClickList);

            // Find and update the trendiest event
            var trendiestEvent = _filteredItems.FirstOrDefault(item => item.EventID == trendiestEventId);
            if (trendiestEvent != null)
            {
                trendiestEvent.Title += "  TRENDING"; // Add markdown syntax for bold
                _filteredItems.Remove(trendiestEvent);
                _filteredItems.Insert(0, trendiestEvent);
            }

            ItemsListBox.ItemsSource = null;
            ItemsListBox.ItemsSource = _filteredItems;
        }




    }
}