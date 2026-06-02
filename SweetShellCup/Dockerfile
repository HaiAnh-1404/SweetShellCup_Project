# Bước 1: Sử dụng SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Sao chép file csproj và restore các dependencies (Nuget)
COPY *.csproj ./
RUN dotnet restore

# Sao chép toàn bộ code còn lại và build dự án
COPY . ./
RUN dotnet publish -c Release -o out

# Bước 2: Sử dụng Runtime nhỏ gọn để chạy ứng dụng (giúp giảm dung lượng image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Cấu hình cổng chạy ứng dụng (mặc định của .NET 8 là 8080)
EXPOSE 8080

# Lệnh để khởi chạy ứng dụng (Thay "TenDuAnCuaBan.dll" bằng file dll thật của bạn)
ENTRYPOINT ["dotnet", "SweetShellCup.dll"]