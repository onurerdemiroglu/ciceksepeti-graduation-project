Feature: Mizu Web UI Tests

    Mizu Web UI Tests with .NET & Specflow (BDD-Framework for .NET)

    @caseone @User_validUserLogin
    Scenario: Valid User Login Control
        Given I am on the home page
        When  I close the address focus on the home page

        And   I go to login page
        And   I logged in with the following data:
            | email                | password |
            | sirdonespe@vusra.com | bootcamp |
        Then  I should see My Account section


    @casetwo @Product_validSorting
    Scenario Outline: Valid Product Sorting Control
        Given  I open the 'flowers' url
        When   I close the address focus on the home page
        And    I sort result list based on <sortCriterion>
        Then   I should see the prices listed from high to low

        Examples:
            | sortCriterion      |
            | Price: High to Low |


    @casetree @Product_displayedEachNewPage
    Scenario: Control The New Products Are Displayed On Each New Page
        Given  I open the 'flowers' url
        When   I close the address focus on the home page
        Then   I scrolling down to page 10 and check see 60 products displayed per page


    @casefour @Payment_validWithOxxo
    Scenario: Payment check with "OXXO"
        Given I open the 'flowers' url
        When  I choose shipping address 'mexico city'
        And   I open the first product page
        And   I select the delivery time and click the add to cart button
        And   I click the Guest Checkout
        And   I fill out the order information form
        And   I fill out the sender information form
        And   I fill out the payment form
        Then  I should see the message we received your order


    @casefive @positive
    Scenario: Customize and add product to the basket
        Given I open the 'en-mx/portarretratos-de-cristal-personalizado-cancion-kcm64138299' url
        When  I add product to basket
        Then  I customize the product



    @casesix @positive
    Scenario: Kırık link kontrolü
        Given I am on the home page
        When  I close the address focus on the home page
        When test





