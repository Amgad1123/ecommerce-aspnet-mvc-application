/*CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);*/

INSERT INTO Users (Username, Email, PasswordHash) VALUES
('JohnDoe', 'john.doe@example.com', 'hashedpassword123'),
('JaneSmith', 'jane.smith@example.com', 'hashedpassword789');

select * from users;