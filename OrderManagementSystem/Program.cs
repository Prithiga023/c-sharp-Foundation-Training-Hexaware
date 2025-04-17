using System.Data.SqlClient;
using OrderManagementSystem.dao;
using OrderManagementSystem.util;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Order Management System =====");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. View Orders by User");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": CreateUser(); break;
                    case "2": CreateProduct(); break;
                    case "3": CreateOrder(); break;
                    case "4": CancelOrder(); break;
                    case "5": ViewAllProducts(); break;
                    case "6": ViewOrdersByUser(); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        static void CreateUser()
        {
            try
            {
                Console.Write("Enter User ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                Console.Write("Enter Role (Admin/User): ");
                string role = Console.ReadLine();

                // Check if the user ID already exists
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    conn.Open();
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE userId = @id";
                    SqlCommand checkCmd = new SqlCommand(checkUserQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Console.WriteLine("Error: A user with this ID already exists.");
                        return;
                    }

                    // If userId is unique, proceed to create user
                    string query = "INSERT INTO Users (userId, username, password, role) VALUES (@id, @username, @password, @role)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User created successfully.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid input format. " + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: Database issue occurred. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void CreateProduct()
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Quantity in Stock: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Type (Electronics/Clothing): ");
            string type = Console.ReadLine();

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string productQuery = "INSERT INTO Product (productId, productName, description, price, quantityInStock, type) VALUES (@id, @name, @desc, @price, @qty, @type)";
                SqlCommand productCmd = new SqlCommand(productQuery, conn);
                productCmd.Parameters.AddWithValue("@id", id);
                productCmd.Parameters.AddWithValue("@name", name);
                productCmd.Parameters.AddWithValue("@desc", description);
                productCmd.Parameters.AddWithValue("@price", price);
                productCmd.Parameters.AddWithValue("@qty", quantity);
                productCmd.Parameters.AddWithValue("@type", type);
                productCmd.ExecuteNonQuery();

                if (type == "Electronics")
                {
                    Console.Write("Enter Brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("Enter Warranty Period (months): ");
                    int warranty = int.Parse(Console.ReadLine());

                    string electronicsQuery = "INSERT INTO Electronics (productId, brand, warrantyPeriod) VALUES (@id, @brand, @warranty)";
                    SqlCommand electronicsCmd = new SqlCommand(electronicsQuery, conn);
                    electronicsCmd.Parameters.AddWithValue("@id", id);
                    electronicsCmd.Parameters.AddWithValue("@brand", brand);
                    electronicsCmd.Parameters.AddWithValue("@warranty", warranty);
                    electronicsCmd.ExecuteNonQuery();
                }
                else if (type == "Clothing")
                {
                    Console.Write("Enter Size: ");
                    string size = Console.ReadLine();
                    Console.Write("Enter Color: ");
                    string color = Console.ReadLine();

                    string clothingQuery = "INSERT INTO Clothing (productId, size, color) VALUES (@id, @size, @color)";
                    SqlCommand clothingCmd = new SqlCommand(clothingQuery, conn);
                    clothingCmd.Parameters.AddWithValue("@id", id);
                    clothingCmd.Parameters.AddWithValue("@size", size);
                    clothingCmd.Parameters.AddWithValue("@color", color);
                    clothingCmd.ExecuteNonQuery();
                }

                Console.WriteLine("Product created successfully.");
            }
        }

        static void CreateOrder()
        {
            Console.Write("Enter User ID to place order: ");
            int userId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                SqlCommand orderCmd = new SqlCommand("INSERT INTO Orders (userId) OUTPUT INSERTED.orderId VALUES (@userId)", conn);
                orderCmd.Parameters.AddWithValue("@userId", userId);
                int orderId = (int)orderCmd.ExecuteScalar();

                Console.Write("Enter number of products to add: ");
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter Product ID: ");
                    int pid = int.Parse(Console.ReadLine());

                    SqlCommand detailsCmd = new SqlCommand("INSERT INTO OrderDetails (orderId, productId) VALUES (@oid, @pid)", conn);
                    detailsCmd.Parameters.AddWithValue("@oid", orderId);
                    detailsCmd.Parameters.AddWithValue("@pid", pid);
                    detailsCmd.ExecuteNonQuery();
                }

                Console.WriteLine("Order placed successfully with Order ID: " + orderId);
            }
        }

        static void CancelOrder()
        {
            Console.Write("Enter Order ID to cancel: ");
            int orderId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                SqlCommand deleteDetails = new SqlCommand("DELETE FROM OrderDetails WHERE orderId = @id", conn);
                deleteDetails.Parameters.AddWithValue("@id", orderId);
                deleteDetails.ExecuteNonQuery();

                SqlCommand deleteOrder = new SqlCommand("DELETE FROM Orders WHERE orderId = @id", conn);
                deleteOrder.Parameters.AddWithValue("@id", orderId);
                deleteOrder.ExecuteNonQuery();

                Console.WriteLine("Order canceled successfully.");
            }
        }

        static void ViewAllProducts()
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["productId"]}, Name: {reader["productName"]}, Price: {reader["price"]}, Stock: {reader["quantityInStock"]}, Type: {reader["type"]}");
                }
            }
        }

        static void ViewOrdersByUser()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT o.orderId, o.orderDate, p.productName, p.price
                                                  FROM Orders o
                                                  JOIN OrderDetails od ON o.orderId = od.orderId
                                                  JOIN Product p ON od.productId = p.productId
                                                  WHERE o.userId = @uid", conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Order ID: {reader["orderId"]}, Product: {reader["productName"]}, Price: {reader["price"]}");
                }
            }
        }
    }
}
