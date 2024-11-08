
CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    Description NVARCHAR(MAX) NOT NULL,
    EventDate DATETIME NOT NULL,
    ItemType NVARCHAR(50) NOT NULL,
    Tag NVARCHAR(50),
    Title NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255),
    CreatedBy NVARCHAR(100),
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedDate DATETIME DEFAULT GETDATE()
);



INSERT INTO Events (Description, EventDate, ItemType, Tag, Title, Location, CreatedBy)
VALUES
('Join us for a comprehensive COVID-19 vaccination drive open to all adults aged 18 and above. This initiative aims to ensure community safety and health. Vaccines will be administered by certified healthcare professionals, with support staff on-site to answer any questions and provide guidance. Remember to bring your ID and vaccination card if you have previously received any doses.', 
 '2024-10-01 10:00:00', 'Announcement', 'Medication', 'Vaccination Drive', 'Community Center', 'Admin'),

('We invite teenagers to join our engaging workshop on financial literacy. Participants will learn essential money management skills, including budgeting, saving, and investing. Experienced financial advisors will lead interactive sessions designed to empower the younger generation with knowledge for a financially secure future.', 
 '2024-11-05 14:00:00', 'Event', 'Education', 'Financial Literacy Workshop', 'Library Hall', 'Admin'),

('Please be advised of a scheduled power outage affecting the downtown area. This maintenance is necessary to upgrade infrastructure and ensure reliable service. During the outage, traffic lights may be non-operational, and businesses may experience temporary disruptions. We apologize for any inconvenience and appreciate your understanding as we work to improve our services.', 
 '2024-10-15 08:00:00', 'Announcement', 'Electricity', 'Power Outage Notice', 'Downtown', 'Admin'),

('Join us for a seminar on investment strategies tailored for beginners. Learn about different asset classes, risk management, and building a diversified portfolio. Our expert speakers will provide valuable insights and practical tips to help you start investing with confidence. This is a great opportunity to enhance your financial knowledge and prepare for a secure future.', 
 '2024-12-01 09:30:00', 'Event', 'Finance', 'Investment Seminar', 'Conference Room A', 'Admin'),

('Prepare for hurricane season with our emergency preparedness event. Learn how to create a family emergency plan, secure your property, and stay informed during severe weather. Experts will provide demonstrations and distribute free emergency kits to attendees. Your safety is our priority, so join us to ensure you and your family are ready for any eventuality.', 
 '2024-10-20 11:00:00', 'Event', 'Disaster', 'Hurricane Preparedness', 'City Hall', 'Admin'),

('The school district is excited to announce a new educational curriculum designed to enhance learning outcomes and foster student engagement. This curriculum incorporates cutting-edge teaching methodologies and resources to support diverse learning styles. Join us for a detailed presentation during which educators will discuss the changes and answer any questions.', 
 '2024-10-30 09:00:00', 'Announcement', 'Education', 'Curriculum Update', 'School District Office', 'Admin'),

('Community members are invited to a meeting to discuss electricity usage and sustainable practices. We will explore ways to reduce consumption and lower utility bills while contributing to environmental conservation. Energy experts will share insights and answer questions, helping you make informed decisions about your energy use.', 
 '2024-11-10 18:00:00', 'Event', 'Electricity', 'Electricity Usage Meeting', 'Community Center', 'Admin'),

('Our finance department is offering valuable tips for small business owners looking to improve financial health. Topics will include cash flow management, tax planning, and access to funding. This announcement aims to provide entrepreneurs with the tools and knowledge to navigate financial challenges and achieve sustainable growth.', 
 '2024-10-25 13:00:00', 'Announcement', 'Finance', 'Small Business Finance Tips', 'Business Bureau', 'Admin'),

('As flu season approaches, we are issuing a public health announcement to remind everyone of the importance of vaccination and preventive measures. Learn about flu symptoms, treatment options, and how to protect yourself and others. Stay informed and take proactive steps to maintain your health during this season.', 
 '2024-11-01 10:00:00', 'Announcement', 'Medication', 'Flu Season Alert', 'Health Department', 'Admin'),

('Volunteers are invited to attend a meeting about our disaster relief fund. Learn how you can contribute to ongoing efforts to support communities affected by recent disasters. We will discuss upcoming projects, funding allocations, and volunteer opportunities. Your involvement is crucial in making a positive impact and providing much-needed assistance.', 
 '2024-11-15 15:00:00', 'Event', 'Disaster', 'Relief Fund Meeting', 'Volunteer Center', 'Admin'),

 ('Attend our free health check-up day where certified doctors will provide basic health screenings and consultations to promote community wellness.', 
 '2024-10-10 09:00:00', 'Announcement', 'Medication', 'Health Check-Up Day', 'Local Clinic', 'Admin'),

('Join the youth coding bootcamp where teens can learn programming basics and develop their own projects. Sessions are led by experienced mentors.', 
 '2024-11-12 10:00:00', 'Event', 'Education', 'Youth Coding Bootcamp', 'Tech Center', 'Admin'),

('A reminder of the scheduled water supply maintenance affecting several neighborhoods. Ensure to store adequate water in advance to minimize disruption.', 
 '2024-10-18 07:00:00', 'Announcement', 'Electricity', 'Water Supply Maintenance', 'City Waterworks', 'Admin'),

('Attend our interactive financial planning seminar for young professionals. Discover strategies for managing debt, saving, and investing wisely.', 
 '2024-12-02 11:00:00', 'Event', 'Finance', 'Financial Planning Seminar', 'Business Hub', 'Admin'),

('Participate in our disaster readiness workshop, focusing on earthquake preparedness. Learn how to protect your home and family with practical tips.', 
 '2024-10-22 14:00:00', 'Event', 'Disaster', 'Earthquake Preparedness', 'Community Hall', 'Admin'),

('The education board announces a new scholarship program to support underprivileged students. Join us for the launch event and learn how to apply.', 
 '2024-11-03 15:00:00', 'Announcement', 'Education', 'Scholarship Program Launch', 'Education Office', 'Admin'),

('Discuss renewable energy solutions at our community meeting. Explore solar and wind options to reduce your carbon footprint and energy costs.', 
 '2024-11-11 17:00:00', 'Event', 'Electricity', 'Renewable Energy Solutions', 'Eco Center', 'Admin'),

('Our finance team presents a workshop on securing funding for startups. Gain insights into venture capital, grants, and crowdfunding.', 
 '2024-10-27 12:00:00', 'Announcement', 'Finance', 'Startup Funding Workshop', 'Innovation Lab', 'Admin'),

('Stay informed on the latest health advisories regarding seasonal allergies. Learn how to manage symptoms and seek appropriate treatment.', 
 '2024-11-02 09:30:00', 'Announcement', 'Medication', 'Seasonal Allergy Advisory', 'Health Clinic', 'Admin'),

('Join our disaster relief volunteer training session to learn how you can assist during emergencies. Your help is crucial in supporting affected communities.', 
 '2024-11-16 16:00:00', 'Event', 'Disaster', 'Volunteer Training Session', 'Relief Center', 'Admin'),

 ('Join us for a wellness workshop focusing on mental health and stress management techniques. Open to all community members seeking support.', 
 '2024-10-05 09:00:00', 'Announcement', 'Medication', 'Mental Health Workshop', 'Wellness Center', 'Admin'),

('Engage in our interactive coding challenge for students, designed to enhance problem-solving skills and coding proficiency.', 
 '2024-11-08 14:00:00', 'Event', 'Education', 'Student Coding Challenge', 'Tech Lab', 'Admin'),

('Notice: Temporary road closures due to essential electrical maintenance. Please plan alternative routes to avoid delays.', 
 '2024-10-17 08:00:00', 'Announcement', 'Electricity', 'Road Closure Notice', 'Downtown Area', 'Admin'),

('Attend our comprehensive finance workshop aimed at helping individuals manage their personal finances and investments effectively.', 
 '2024-12-03 11:00:00', 'Event', 'Finance', 'Personal Finance Workshop', 'Finance Center', 'Admin'),

('Prepare for winter storms with our safety briefing and resources. Learn how to protect your property and ensure family safety during severe weather.', 
 '2024-10-21 10:00:00', 'Event', 'Disaster', 'Winter Storm Preparedness', 'City Hall', 'Admin'),

('The education department announces a new online learning platform to enhance remote education. Discover the features and benefits at our launch event.', 
 '2024-11-04 10:00:00', 'Announcement', 'Education', 'Online Learning Platform', 'Education Office', 'Admin'),

('Join the discussion on sustainable energy practices at our community forum. Explore options for reducing energy consumption and costs.', 
 '2024-11-13 18:00:00', 'Event', 'Electricity', 'Sustainable Energy Forum', 'Eco Center', 'Admin'),

('Learn about effective tax strategies for small businesses in our upcoming seminar. Gain insights from leading financial experts.', 
 '2024-10-28 13:00:00', 'Announcement', 'Finance', 'Small Business Tax Strategies', 'Business Bureau', 'Admin'),

('Stay alert with our public health advisory on emerging respiratory illnesses. Learn preventive measures to protect yourself and your family.', 
 '2024-11-03 09:30:00', 'Announcement', 'Medication', 'Respiratory Health Advisory', 'Health Department', 'Admin'),

('Participate in our emergency response training to become a certified disaster relief volunteer. Your support is vital in crisis situations.', 
 '2024-11-17 15:00:00', 'Event', 'Disaster', 'Emergency Response Training', 'Relief Center', 'Admin'),

 ('Attend our workshop on managing chronic pain with medication and lifestyle changes. Open to all seeking advice from health professionals.', 
 '2024-10-08 09:00:00', 'Announcement', 'Medication', 'Chronic Pain Management', 'Health Center', 'Admin'),

('Join our science fair where students showcase innovative projects. Discover new ideas and support young minds in their scientific pursuits.', 
 '2024-11-09 13:00:00', 'Event', 'Education', 'Science Fair', 'School Auditorium', 'Admin'),

('Notice: Power line upgrades will occur next week, causing brief outages. Please prepare accordingly and follow safety guidelines.', 
 '2024-10-19 07:00:00', 'Announcement', 'Electricity', 'Power Line Upgrades', 'Main Street', 'Admin'),

('Discover investment opportunities in our financial growth seminar. Learn from experts how to diversify and secure your financial future.', 
 '2024-12-04 10:30:00', 'Event', 'Finance', 'Financial Growth Seminar', 'Investment Center', 'Admin'),

('Get ready for wildfire season with our safety briefing. Learn evacuation plans and how to safeguard your home in case of emergencies.', 
 '2024-10-22 14:00:00', 'Event', 'Disaster', 'Wildfire Safety Briefing', 'Community Hall', 'Admin'),

('The education board introduces a digital literacy campaign to enhance tech skills. Join us to learn more about resources and programs.', 
 '2024-11-07 11:00:00', 'Announcement', 'Education', 'Digital Literacy Campaign', 'Library', 'Admin'),

('Participate in our renewable energy workshop to explore solar and wind power solutions. Ideal for homeowners and businesses.', 
 '2024-11-14 17:00:00', 'Event', 'Electricity', 'Renewable Energy Workshop', 'Green Tech Center', 'Admin'),

('Our finance team presents insights on retirement planning in our upcoming webinar. Prepare for a secure and comfortable retirement.', 
 '2024-10-29 12:00:00', 'Announcement', 'Finance', 'Retirement Planning Webinar', 'Virtual Event', 'Admin'),

('Stay informed on the latest medication updates for chronic conditions. Learn about new treatments and management strategies.', 
 '2024-11-04 09:00:00', 'Announcement', 'Medication', 'Medication Update', 'Pharmacy', 'Admin'),

('Join our disaster preparedness training to become a community leader in emergencies. Equip yourself with vital skills and knowledge.', 
 '2024-11-18 16:00:00', 'Event', 'Disaster', 'Disaster Preparedness Training', 'Emergency Center', 'Admin'),

 ('Join our session on the latest advancements in pain relief therapies. Open to all interested in learning about modern medical solutions.', 
 '2024-10-09 10:00:00', 'Announcement', 'Medication', 'Pain Relief Innovations', 'Medical Center', 'Admin'),

('Participate in our career day event featuring workshops on various professions. Ideal for students exploring future career paths.', 
 '2024-11-10 15:00:00', 'Event', 'Education', 'Career Day', 'High School Gym', 'Admin'),

('Important notice: Electrical maintenance will cause temporary disruptions. Ensure backup plans are in place for essential operations.', 
 '2024-10-20 09:00:00', 'Announcement', 'Electricity', 'Electrical Maintenance Alert', 'Business District', 'Admin'),

('Explore investment ideas at our seminar focused on sustainable and ethical investing. Learn how to grow your wealth responsibly.', 
 '2024-12-05 10:30:00', 'Event', 'Finance', 'Ethical Investing Seminar', 'Finance Hub', 'Admin'),

('Prepare for flood season with our community readiness event. Learn how to protect your property and family from potential flooding.', 
 '2024-10-23 13:00:00', 'Event', 'Disaster', 'Flood Preparedness', 'Town Hall', 'Admin'),

('The school district is launching a new reading initiative to boost literacy rates. Discover resources and support available for students.', 
 '2024-11-06 14:00:00', 'Announcement', 'Education', 'Reading Initiative Launch', 'District Office', 'Admin'),

('Join our workshop on reducing electricity consumption at home. Gain tips and techniques to save energy and reduce bills.', 
 '2024-11-15 18:30:00', 'Event', 'Electricity', 'Energy Saving Workshop', 'Community Center', 'Admin'),

('Our finance team hosts a session on budgeting basics for families. Learn how to manage expenses and save for future goals.', 
 '2024-10-30 11:00:00', 'Announcement', 'Finance', 'Family Budgeting Basics', 'Local Library', 'Admin'),

('Attend our health talk on managing seasonal allergies effectively. Get advice from experts on prevention and treatment.', 
 '2024-11-05 08:30:00', 'Announcement', 'Medication', 'Allergy Management Talk', 'Health Clinic', 'Admin'),

('Join our emergency services training to become an active volunteer during disasters. Help your community by gaining essential skills.', 
 '2024-11-19 14:00:00', 'Event', 'Disaster', 'Emergency Volunteer Training', 'Relief Center', 'Admin'),

 ('Discover new approaches to managing chronic conditions with medication. Open to patients and caregivers seeking updated information.', 
 '2024-10-11 11:00:00', 'Announcement', 'Medication', 'Chronic Condition Management', 'City Hospital', 'Admin'),

('Explore the world of robotics in our interactive workshop for students. Learn about programming and building robots.', 
 '2024-11-11 10:00:00', 'Event', 'Education', 'Robotics Workshop', 'Tech Institute', 'Admin'),

('Alert: Scheduled maintenance will affect power supply in the industrial area. Businesses should plan accordingly to minimize impact.', 
 '2024-10-21 08:00:00', 'Announcement', 'Electricity', 'Power Supply Maintenance', 'Industrial Zone', 'Admin'),

('Join our seminar on personal finance strategies for young adults. Learn to manage debt and build a solid financial foundation.', 
 '2024-12-06 09:30:00', 'Event', 'Finance', 'Personal Finance Strategies', 'Youth Center', 'Admin'),

('Prepare for potential earthquakes with our safety seminar. Learn how to create emergency kits and secure your home effectively.', 
 '2024-10-24 12:00:00', 'Event', 'Disaster', 'Earthquake Safety Seminar', 'Community Hall', 'Admin'),

('Announcing a new digital curriculum designed to enhance online learning experiences. Join us for an overview and implementation details.', 
 '2024-11-08 13:00:00', 'Announcement', 'Education', 'Digital Curriculum Overview', 'Education Center', 'Admin'),

('Attend our session on optimizing renewable energy use at home. Discover practical ways to integrate solar and wind power.', 
 '2024-11-16 17:00:00', 'Event', 'Electricity', 'Renewable Energy Integration', 'Green Building', 'Admin'),

('Learn about tax-efficient investing in our upcoming workshop. Gain insights into maximizing returns while minimizing tax liabilities.', 
 '2024-10-31 10:00:00', 'Announcement', 'Finance', 'Tax-Efficient Investing', 'Financial Plaza', 'Admin'),

('Stay informed with our seminar on flu prevention and treatment options. Get expert advice on staying healthy during flu season.', 
 '2024-11-06 09:30:00', 'Announcement', 'Medication', 'Flu Prevention Seminar', 'Community Health Center', 'Admin'),

('Join our disaster response team training and learn how to assist effectively in emergencies. Your skills can make a difference.', 
 '2024-11-20 15:00:00', 'Event', 'Disaster', 'Disaster Response Training', 'Emergency Operations Center', 'Admin');



--DELETE FROM Events;