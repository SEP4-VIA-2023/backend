using Microsoft.EntityFrameworkCore;
using Model;
using NUnit.Framework;
using System.Text;
using EFCDataAccess;
using EFCDataAccess.DAOs;


[TestFixture]
    public class UserDAOTests
    {
        

    
        [Test]
        public async Task CreateAsync_ShouldCreateUser()
        {
            // Arrange
            using (var context = new DataContext())
            {
                var userDAO = new UserDAO(context);
                var user = new User(
                    name: "John Doe",
                    password: Encoding.UTF8.GetBytes("password123"),
                    salt: Encoding.UTF8.GetBytes("salt123"),
                    email: "test@example.com"
                );

                // Act
                var createdUser = await userDAO.CreateAsync(user);

                // Assert
                Assert.IsNotNull(createdUser);
                Assert.AreEqual(user.Name, createdUser.Name);
                Assert.AreEqual(user.Email, createdUser.Email);
                // Add more assertions as needed
            }
        }

        [Test]
        public async Task GetByEmail_ShouldReturnUserIfExists()
        {
            // Arrange
            using (var context = new DataContext())
            {
                var userDAO = new UserDAO(context);
                var user = new User(
                    name: "John Doe",
                    password: Encoding.UTF8.GetBytes("password123"),
                    salt: Encoding.UTF8.GetBytes("salt123"),
                    email: "test@example.com"
                );
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                // Act
                var retrievedUser = await userDAO.GetByEmail("test@example.com");

                // Assert
                Assert.IsNotNull(retrievedUser);
                Assert.AreEqual(user.Name, retrievedUser.Name);
                Assert.AreEqual(user.Email, retrievedUser.Email);
                // Add more assertions as needed
            }
        }
    }

