#  .NET & SpecFlow (BDD-Framework for .NET) ile Mizu Web UI Testleri  

Merhaba, bu projede .Net dilinde NUnit, Selenium, WebDriverManager, SpecFlow, InputSimulator kütüphaneleri kullanılarak Mizu sitesinin UI(User Interface) testleri yapılmaktadır. 
- [X] NUnit'i, .Net diliyle test geliştirmek,
- [X] Selenium'u, test yapılarını otomatikleştirmek,
- [X] SpecFlow'u, .Net dilinde BDD gherkin yapısını kullanmak,
- [X] WebDriverManager'i, her browser için farklı bir driver indirmemek ve aksini belirtmedikçe driverın son versiyonunu indirmesi için,
- [X] Ve son olarak InputSimulator'u ürün kişiselleştirme senaryosundaki openfiledialog'u kapatmak için kullandım 🙂


#### 👉 Testlerinizi yürütmenin yollarından biri, VS Code terminalini kullanmaktır. Dotnet testinde terminali açmanız ve gerekli parametreleri girip enter tuşuna basmanız yeterlidir

Tüm testleri koşmak için : `dotnet test`

Tag'a bağlı testleri koşmak için : `dotnet test --filter Category=casetag`
 


### 👨🏿‍💻 Senaryo-1 : Geçerli Oturum Açma Kontrolü
---

```cucumber
@caseone @User_validUserLogin
Scenario: Valid User Login Control
    Given I am on the home page
    When  I close the address focus on the home page

    And   I go to login page
    And   I logged in with the following data:
        | email                | password |
        | sirdonespe@vusra.com | bootcamp |
    Then  I should see My Account section
```


https://user-images.githubusercontent.com/35347777/149663370-3e4768ea-0265-4621-a0b0-ef7353d45784.mp4
 
 
#### 📝 SpecFlow LivingDoc Raporu
---

![caseone](https://user-images.githubusercontent.com/35347777/149358705-40ce72e1-71f5-409f-b622-b37c338adb8f.PNG)

**Sonuç :** `Başarılı bir şekilde login olunduğu görülmüştür. ✅`

### 👨‍💻 Senaryo-2 : Geçerli Ürün Sıralama Kontrolü
---
Pc video kayıtta olduğundan çok yavaşlıyor ve test uzuyor(Video kırptım). Gerçek test süresi raporda olduğu gibidir.

```cucumber
@casetwo @Product_validSorting
Scenario Outline: Valid Product Sorting Control
    Given  I open the 'flowers' url
    When   I close the address focus on the home page
    And    I sort result list based on <sortCriterion>
    And    I scroll to the end of the page
    Then   I should see the prices listed from high to low

    Examples:
        | sortCriterion      |
        | Price: High to Low |
```
  
https://user-images.githubusercontent.com/35347777/149663418-cf983ef7-4f0e-4411-af3e-f3648c39e5b3.mp4
 
 
#### 📝 SpecFlow LivingDoc Raporu
---

![casetwo](https://user-images.githubusercontent.com/35347777/149662317-9de5efc7-b6cb-4d3c-912c-ad34141e3f85.png) 

**Sonuç :** `Ürünlerin fiyatları başarılı bir şekilde sıralandığı görülmüştür. ✅`

### 👨🏿‍💻 Senaryo-3 : Her Yeni Sayfada Yeni Ürünlerin Görüntülenme Kontrolü
---

```cucumber
@casetree @Product_displayedEachNewPage
Scenario: Control The New Products Are Displayed On Each New Page
    Given  I open the 'flowers' url
    When   I close the address focus on the home page
    Then   I scrolling down to page 10 and check see 60 products displayed per page
```
 


https://user-images.githubusercontent.com/35347777/149663440-fb668dfd-0e4c-4196-8436-9ded405fdaed.mp4
 
 
#### 📝 SpecFlow LivingDoc Raporu
---

![casetree](https://user-images.githubusercontent.com/35347777/149365123-7cfdf716-9147-4d2f-b24e-e51a94d8ac33.PNG)
 

**Sonuç :** `Başarılı bir şekilde her sayfada 60 ürün geldiği görülmüştür. ✅`

### 👨‍💻 Senaryo-4 : "OXXO" ile Ödeme Kontrolü
---

```cucumber
@casefour @Payment_validWithOxxo
Scenario: Payment Check With "OXXO"
    Given I open the 'flowers' url
    When  I choose shipping address 'mexico city'
    And   I open the first product page
    And   I select the delivery time and click the add to cart button
    And   I click the Guest Checkout
    And   I fill out the order information form
    And   I fill out the sender information form
    And   I fill out the payment form
    Then  I should see the message we received your order
```
  
 

https://user-images.githubusercontent.com/35347777/149663530-d911c7b9-b66a-498e-9310-ab467cd7c246.mp4


#### 📝 SpecFlow LivingDoc Raporu
---
 
![casefour](https://user-images.githubusercontent.com/35347777/149365308-c5121813-9df9-4a8f-b23a-dd5657b0e51e.PNG)


**Sonuç :** `Başarılı bir şekilde OXXO ile ödeme yapıldığı görülmüştür. ✅`

### 👨🏿‍💻 Senaryo-5 : Ürünü Özelleştirme ve Sepete Ekleme
---

```cucumber
@casefive @Product_customizeAndBasket
Scenario: Customizing Product And Add To Basket
    Given I open the 'en-mx/portarretratos-de-cristal-personalizado-cancion-kcm64138299' url
    When  I add product to basket
    And   I customize the product and click next button
    Then  I should see the product added to basket
```
 

https://user-images.githubusercontent.com/35347777/149663465-b068750e-6b2e-413a-b93b-9d24582bd696.mp4
  
#### 📝 SpecFlow LivingDoc Raporu
---

 ![casefive](https://user-images.githubusercontent.com/35347777/149365533-dd9ee7ab-5562-4326-b3f1-3bb0609468c0.PNG)


**Sonuç :** `Ürün kişiselleştirilip başarılı bir şekilde sepete eklendiği görülmüştür. ✅`

### 👨‍💻 Senaryo-6 : Menü Bağlantılarının Bozuk Olup Olmadığını Kontrol Etme
---

```cucumber
@casesix @Menu_brokenLinks
    Scenario: Checking If Menu Links Are Broken
    Given I am on the home page
    When  I close the address focus on the home page
    And   I find all the links under the menu
    Then  I should see the links are not broken
```
   

https://user-images.githubusercontent.com/35347777/149663471-fd8ce362-ce8e-4764-aebd-5d17d03e1686.mp4
 
#### 📝 SpecFlow Living Raporu
---

 ![casesix](https://user-images.githubusercontent.com/35347777/149365731-a64a7b20-c0d0-49af-8cfa-48b6c10e3cc6.PNG)


**Sonuç :** `Menü linklerin birinde kırık link tespit edilmiştir. (https://www.mizu.com/new-products-gourmet) ❌`

