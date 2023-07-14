Feature: User Management API
    As a user
    I want to create and retrieve user information
    So that I can verify the functionality of the API

Scenario: Create and Retrieve User
    Given I have the following user information
        | id    | username    | firstName | lastName | email        | password | phone   | userStatus |
        | 43433 | 323243431qw | RRRR      | LLL      | we@gmail.com | 23dwewe  | 2324433 | 0          |

    When I send a POST request to "https://petstore.swagger.io/v2/user/createWithArray" with the user information
    Then the response status code should be 200

    When I send a GET request to "https://petstore.swagger.io/v2/user/323243431qw"
    Then the response status code should be 200
    And the response should contain the following details
        | id    | username    | firstName | lastName | email        | password | phone   | userStatus |
        | 43433 | 323243431qw | RRRR      | LLL      | we@gmail.com | 23dwewe  | 2324433 | 0          |