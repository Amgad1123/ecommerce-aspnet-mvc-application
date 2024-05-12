# NutriActive Supplements - Ecommerce Website

Welcome to NutriActive Supplements, your premier destination for top-quality supplements! This repository contains the source code for our ecommerce platform designed to provide users with a seamless shopping experience for a wide range of supplements.

## Introduction
NutriActive Supplements is committed to offering a diverse selection of supplements to support your health and wellness journey. Our platform is designed with user convenience and satisfaction in mind, ensuring easy navigation, detailed product information, and a hassle-free shopping experience.

## Features
- **Extensive Product Catalog**: Explore a comprehensive catalog of supplements catering to various health needs.
- **Detailed Product Descriptions**: Access detailed information about each product, including ingredients, usage instructions, and customer reviews.
- **Search Functionality**: Easily find specific products using our search feature.
- **User Accounts**: Create accounts to manage orders and save favorite products for future purchases.
- **Responsive Design**: Enjoy a seamless shopping experience across different devices, including desktops, tablets, and smartphones.

## Installation
To set up NutriActive Supplements locally, follow these steps:
NOTE: SSMS must be installed. 
1. Clone this repository to your local machine.
2. Open the project directory.
3. Open solution explorer.
4. Execute the database query from the wwwroot folder. (It will ask to connect to a database)
5. Fill out information to connect to an SSMS database. (Server Name: The name you use to connect to a local database in SSMS, Authentication: Windows Authentication, Database Name: The database you are trying to connect to, Encrypt: Optional (False), Trust Server Certificate: True)
6. After finished executing the database, open Server Explorer in View tab.
7. Generate your connection string by going to Data Connections -> Add Connection.
8. Fill out information to connect to the database you just created. (Alternatively, starting from step 3, start by running the query in an SSMS database and then creating a connection string to that database.)
9. Copy the connection string by going to the newly generated connection string -> Properties.
10. Paste that connection string using similar formating to what is in appsettings.json. 
11. Run `https` or 'IIS Express' on your preferred web browser.

## Usage
Once the application is running in your web browser, you can start exploring the catalog and view detailed product descriptions.

![Website Home Page](/wwwroot/images/homePage.png)

---

Thank you for choosing NutriActive Supplements for your supplement needs! If you have any questions, feedback, or encounter any issues, feel free to open an issue or contact us directly. Happy shopping!

---

![Website Home Page](/wwwroot/images/tests.png)

We were able to get test cases to run and pass locally but ran into issues pushing the test cases onto the git repo. Rather than submitting nothing, we thought we would submit at least some evidence.

