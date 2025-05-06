# Reimbursly 💸

Reimbursly, çalışan masraflarını dijital olarak yönetmenizi sağlayan, rol bazlı yetkilendirme ve onaylama süreçlerine sahip bir Expense Management System'dir.

## 📌 Features

- ✅ Clean Architecture (6 katmanlı yapı)
- ✅ Entity Framework Core
- ✅ JWT Authentication
- ✅ Role-Based Authorization (Uzman, Müdür, Direktör, CEO, Admin)
- ✅ Multi-step expense approval
- ✅ File upload (receipt)
- ✅ Swagger UI ile test edilebilir API
- ✅ Fluent Validation ile veri doğrulama
- ✅ Seed Data ile hazır demo ortamı

## 🛠 Technologies

- .NET 8 Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- BCrypt.Net (Password Hashing)
- Swagger (Swashbuckle)
- SQL Server
- Clean Code & SOLID principles

## 📁 Project Structure

Reimbursly.API → API katmanı (controllers & startup)  
Reimbursly.Application → DTOs, Interfaces, Validation  
Reimbursly.Domain → Entities, Enums  
Reimbursly.Infrastructure → Services, AutoMapper, Auth, FileService  
Reimbursly.Persistence → DbContext, Configurations, Seed Data  
Reimbursly.Shared → Ortak helper yapılar (ApiResponse, Extensions)  


## 🧪 Swagger Test

- Run the project and navigate to:  
  `https://localhost:{port}/swagger`

- JWT token aldıktan sonra:
  - 🔐 "Authorize" butonuna tıkla
  - Token'ı `Bearer {token}` formatında gir

## 🔐 Demo Users

| Role         | Email               | Password     |
|--------------|---------------------|--------------|
| Admin        | admin@company.com   | Admin123!    |
| Employee     | demo@company.com    | Demo123!     |

## 📦 Seed Data

- Roles, Employees, Expense Categories, Payment Methods, Locations
- 1 onaylı, 1 reddedilmiş ve 1 pending masraf örneği
- Rejection Reason örnekleri

## 📝 How to Run

1. Clone the repository
2. Update `appsettings.json` with your SQL Server connection string
3. Run migrations:

   ```bash
   Add-Migration InitialCreate -StartupProject Reimbursly.API -Project Reimbursly.Persistence
   Update-Database -StartupProject Reimbursly.API -Project Reimbursly.Persistence
   ```
Start the API and open Swagger


Author
Developed by Aysel Bilmez
Papara Kadın Yazılımcı Bootcamp – Final Project 💼
