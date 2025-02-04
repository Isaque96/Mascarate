# 🎭 Mascarate

Mascarate is a lightweight and easy-to-use library for formatting, validating, and removing masks in C# strings. Ideal for handling data such as CPF, CNPJ, phone numbers, ZIP codes, and much more. With Mascarate, you can apply and remove masks simply and efficiently, ensuring data consistency and validation in your applications.

## 🚀 Main Features

✅ **Apply Masks**: Format strings with custom masks.

✅ **Remove Masks**: Quickly and easily remove masks from strings.

✅ **Data Validation**: Check if a string matches the specified mask.

✅ **Flexible Configuration**: Define custom masks with special characters.

✅ **Lightweight and Efficient**: Optimized for performance and low memory consumption.

## 📦 Installation

You can install Mascarate via NuGet:

```bash
dotnet add package Mascarate
```

Or through the NuGet Package Manager in Visual Studio:

```bash
Install-Package Mascarate
```

## 🛠 How to Use

### 1. Applying Masks

Use the `Apply` method to format a string with a mask:

```csharp
using Mascarate;

string cpf = "12345678901";
string maskedCpf = Mascarate.Mask.Apply(cpf, "###.###.###-##"); // Result: "123.456.789-01"
```

### 2. Removing Masks

Use the `Remove` method to remove masks from a string:

```csharp
using Mascarate;

string maskedCpf = "123.456.789-01";
string unmaskedCpf = Mascarate.Mask.Remove(maskedCpf); // Result: "12345678901"
```

### 3. Validating Masks

Use the `Validate` method to check if a string matches the specified mask:

```csharp
using Mascarate;

string cpf = "123.456.789-01";
bool isValid = Mascarate.Mask.Validate(cpf, "###.###.###-##"); // Result: true
```

### 4. Custom Masks

You can create custom masks using the following special characters:

- `#`: Any numeric character ([0-9]).
- `@`: Any alphabetic character ([A-Za-z]).
- `*`: Any alphanumeric character ([A-Za-z0-9]).

Example:

```csharp
using Mascarate;

string phoneNumber = "11987654321";
string maskedPhone = Mascarate.Mask.Apply(phoneNumber, "(##) #####-####"); // Result: "(11) 98765-4321"
```

## 📚 Practical Examples

### CPF

```csharp
string cpf = "12345678901";
string maskedCpf = Mascarate.Mask.Apply(cpf, "###.###.###-##"); // "123.456.789-01"
string unmaskedCpf = Mascarate.Mask.Remove(maskedCpf); // "12345678901"
bool isValidCpf = Mascarate.Mask.Validate(maskedCpf, "###.###.###-##"); // true
```

### CNPJ

```csharp
string cnpj = "12345678000199";
string maskedCnpj = Mascarate.Mask.Apply(cnpj, "##.###.###/####-##"); // "12.345.678/0001-99"
string unmaskedCnpj = Mascarate.Mask.Remove(maskedCnpj); // "12345678000199"
bool isValidCnpj = Mascarate.Mask.Validate(maskedCnpj, "##.###.###/####-##"); // true
```

### Phone Number

```csharp
string phoneNumber = "11987654321";
string maskedPhone = Mascarate.Mask.Apply(phoneNumber, "(##) #####-####"); // "(11) 98765-4321"
string unmaskedPhone = Mascarate.Mask.Remove(maskedPhone); // "11987654321"
bool isValidPhone = Mascarate.Mask.Validate(maskedPhone, "(##) #####-####"); // true
```

### ZIP Code

```csharp
string zipCode = "12345678";
string maskedZip = Mascarate.Mask.Apply(zipCode, "#####-###"); // "12345-678"
string unmaskedZip = Mascarate.Mask.Remove(maskedZip); // "12345678"
bool isValidZip = Mascarate.Mask.Validate(maskedZip, "#####-###"); // true
```

## 📜 Special Characters for Masks

- `#`: Any number ([0-9]).
- `@`: Any letter ([A-Za-z]).
- `*`: Any alphanumeric character ([A-Za-z0-9]).

## 🤝 Contributing

Contributions are welcome! If you want to contribute to Mascarate, follow these steps:

1. Fork the repository.
2. Create a branch with your feature or fix:

   ```bash
   git checkout -b my-feature
   ```

3. Commit your changes:

   ```bash
   git commit -m "My new feature"
   ```

4. Push to the remote repository:

   ```bash
   git push origin my-feature
   ```

5. Open a pull request on GitHub.

## 📄 License

This project is licensed under the MIT License. See the LICENSE file for more details.

## 🙏 Acknowledgments

Thank you for using Mascarate! If you enjoyed the project, leave a ⭐ on the repository and share it with other developers.

