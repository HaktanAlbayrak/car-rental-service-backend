using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public class Messages
{
    // Car
    public static string CarAdded = "Car Added";
    public static string CarDeleted = "Car Deleted";
    public static string CarUpdated = "Car Updated";
    public static string CarsListed = "Cars Listed";
    public static string CarIsAlreadyRented = "Car is already rented!";
    public static string NoCarIsAvailable = "No cars are available in the system.";

    //Color
    public static string ColorAdded = "Color Added";
    public static string ColorDeleted = "Color Deleted";
    public static string ColorUpdated = "Color Updated";
    public static string ColorsListed = "Colors Listed";

    // Brand
    public static string BrandAdded = "Brand Added";
    public static string BrandDeleted = "Brand Deleted";
    public static string BrandUpdated = "Brand Updated";
    public static string BrandsListed = "Brands Listed";

    //Rental
    public static string RentalAdded = "Rental Added";
    public static string RentalDeleted = "Rental Deleted";
    public static string RentalUpdated = "Rental Updated";
    public static string RentalsListed = "Rentals Listed";

    //User 
    public static string ExistingUser = "User is exist";
    public static string UserAdded = "User Added";
    public static string UserDeleted = "User Deleted";
    public static string UserUpdated = "User Updated";
    public static string UsersListed = "User Listed";

    //Customer
    public static string ExistingCustomer = "Customer is exist";
    public static string CustomerAdded = "Customer Added";
    public static string CustomerDeleted = "Customer Deleted";
    public static string CustomerUpdated = "Customer Updated";
    public static string CustomersListed = "Customer Listed";

    //Car Image
    public static string CarImageLimitReached = "A car can have up to 5 pictures!";
    public static string FileUploadError = "An error occurred while uploading the file.";
    public static string InvalidFile = "Invalid file.";
    public static string ImageAdded = "Image added successfully.";
    public static string ImageDeleted = "Image deleted successfully.";
    public static string ImageUpdated = "Image updated successfully.";

    // Auth
    public static string AuthorizationDenied = "You do not have permission";
    public static string UserNotFound = "User not found";
    public static string PasswordError = "Incorrect password";
    public static string SuccessfulLogin = "Login successful";
    public static string UserAlreadyExists = "This user already exists";
    public static string UserRegistered = "User registered successfully";
    public static string AccessTokenCreated = "Access token created successfully";

}
