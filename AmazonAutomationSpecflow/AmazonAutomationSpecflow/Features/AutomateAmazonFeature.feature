Feature: Shopping Cart Functionality

Scenario: Add item to cart and validate
    Given I am an unregistered user on Amazon website
    When I search for "TP-Link N450 WiFi Router - Wireless Internet Router for Home (TL-WR940N)"
    And I add the corresponding item to the cart
    