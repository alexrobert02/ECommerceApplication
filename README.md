# ECommerceApplication

**ECommerceApplication** is a modern e-commerce platform where users can search for products, view detailed information, and manage their shopping cart. Companies can list their products, enabling seamless interactions between buyers and sellers in a user-friendly environment.

## Features
* **User Functionality**:
  * **Search Products**: Users can search for products based on categories, keywords, or filters.
  * **View Product Details**: Users can see detailed product information such as description, price, and availability.
  * **Post Reviews**: Users can leave reviews and rate products they have purchased to help others make informed decisions.
  * **Shopping Cart**: Users can add products to their shopping card and proceed to checkout.
  * **Manage Shipping Addresses**: Users can add, edit, and select from multiple shipping addresses during checkout.
* **Company Functionality**:
  * **Post Products**: Companies can post new products to the platform, including images, descriptions and pricing.

## Technologies
* **Frontend**: Blazor
* **Backend**: .NET
* **Database**: PostgreSQL

## Pages
### Home Page
![Image](https://github.com/user-attachments/assets/7ab767e0-742c-4aef-9d72-0d90bfcfe75d)
### Products Page
![Image](https://github.com/user-attachments/assets/ef1ec8a2-6633-4e28-90fe-c6fdb53b3a31)
### Product Details Page
![Image](https://github.com/user-attachments/assets/9edf9cfa-b88b-401e-b7e5-383f8bd0d20c)
![Image](https://github.com/user-attachments/assets/9a0ca467-8c15-4a16-bf0a-2de415b32bca)
### Checkout Page
![Image](https://github.com/user-attachments/assets/1a7de5ff-6d3d-46fb-8f2b-fb2944e96755)

## Setup
1. Set up the database and run migrations:
   1. Open the Package Manager Console in Visual Studio.
   2. To apply migrations for the **main application schema**, set the default project to `src\Infrastructure\ECommerceApplication.Infrastructure`, then run:
         ```
         Update-Database -Context ECommerceApplicationContext
         ```
   2. To apply migrations for **user authentication and identity management**, set the default project to `src\Infrastructure\ECommerceApplication.Identity`, then run:
         ```
         Update-Database -Context ApplicationDBContext
         ```
2. Run both `EcommerceApplication.Api`(Blazor app) and `ECommerceApplication.App`(backend API).

## Contributors
- Robert-Alexandru Zaharia
- Ana-Maria Constantin
- Alexandru Duca
- Marius Achitei
