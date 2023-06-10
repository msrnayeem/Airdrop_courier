## Courier Tracking System

The Courier Tracking System is a web application developed using C#, ASP.NET MVC, and follows a 3-tier architecture. It enables customers to track their shipments by entering the tracking number, while administrators can efficiently manage courier services and shipment statuses. The system utilizes MySQL as the underlying database for data storage and retrieval.

### Features

- **Customer Tracking**: Customers can track their shipments by entering the provided tracking number, gaining real-time information about the status and location of their packages.
- **Admin Management**: Administrators have full control over courier services and can efficiently manage shipment statuses, update tracking details, and provide accurate information to customers.
- **Edit and Update Functionality**: Administrators can edit and update customer information, including personal details and contact information. They can also modify shipment details such as destination, weight, and delivery instructions. Additionally, administrators can update tracking information, such as current status and location.
- **Export Functionality**: Administrators have the capability to export lists of data, such as customer information, shipments, and tracking details, to CSV, Excel, and PDF formats. This feature allows for easy sharing, analysis, and reporting of the data.

### Architecture

The Courier Tracking System is developed using C#, ASP.NET MVC, and MySQL database, following a 3-tier architecture. The layers include:

1. **Presentation Layer**: Implements the user interfaces for customers and administrators using ASP.NET MVC, providing seamless interaction and data display.
2. **Business Logic Layer**: Handles business rules and processes, performing operations like tracking shipments, managing courier services, updating shipment statuses, editing/updating customer and tracking information, and exporting data to different formats.
3. **Data Access Layer**: Manages the retrieval and storage of data from the MySQL database, allowing seamless communication between the application and the data source. Administrators can access and modify customer, shipment, and tracking data, as well as export the data to CSV, Excel, and PDF formats.

### Prerequisites

- Visual Studio with ASP.NET MVC framework
- MySQL database

### Installation

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the MySQL database connection in the web.config file.
4. Run migration [AUTO-Migration]
5. Build and run the application.

### Usage

1. Open the application in a web browser.
2. Customers can enter their tracking number to track their shipments.
3. Administrators can log in to the admin panel to manage courier services, update shipment statuses, and edit customer and tracking information.
4. Administrators can also export lists of data to CSV, Excel, and PDF formats for further analysis and reporting.

### Contributing

Contributions are welcome! Please follow the standard pull request process.

### License

This project is licensed under the [MIT License](LICENSE).

### Acknowledgements

- [ASP.NET MVC Documentation](https://docs.microsoft.com/en-us/aspnet/mvc/)
- [MySQL Documentation](https://dev.mysql.com/doc/)
