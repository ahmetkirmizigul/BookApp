# BookApp

## 📌 Database Setup  
Bu proje, SQL Server kullanarak çalışmaktadır ve Stored Procedure'lar ile işlemler yapılmaktadır.  
Aşağıdaki adımları izleyerek veritabanını oluşturabilirsiniz:  

1️⃣ **Yeni bir SQL Server veritabanı oluştur:**  
   - **Adı:** `BookAppDB`  
2️⃣ **Entity Framework Migrations Çalıştır:**  
3️⃣ **Stored Procedure'ları yükle:**  
- SQL Server Management Studio (SSMS) aç  
- `DataAccess/StoredProcedures.sql` dosyasını çalıştır:
  ```
  USE BookAppDB;
  GO
  EXEC sp_executesql N'StoredProcedures.sql'
  ```
