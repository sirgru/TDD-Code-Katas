# Katas

## Kata 1 - String Calculator

http://osherove.com/kata
Before you start:
* Try not to read ahead.
* Do one task at a time. The trick is to learn to work incrementally.
* Make sure you only test for correct inputs. There is no need to test for invalid inputs for this kata.
* Test First!

String Calculator
1. In a test-first manner, create a simple class StringCalculator with a method `public int Add(string numbers)`.
* The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example:

		"" == 0 , "1" == 1 , "1,2" == 3

* Start with the simplest test case of an empty string and move to one & two numbers.
* Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
* Remember to refactor after each passing test
2. Allow the Add method to handle an unknown amount of numbers.
3. Allow the Add method to handle new lines between numbers (instead of commas).
* The following input is ok: `"1\n2,3" == 6`.
* The following is INVALID input so do not expect it : "1,\n" (not need to write a test for it).
4. Support different delimiters: to change a delimiter, the beginning of the string will contain a separate line
that looks like this: 

		"//[delimiter]\n[numbers…]"

for example

		"//;\n1;2" == 3

since the default delimiter is ';'.
Note: All existing scenarios and tests should still be supported.
5. Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative that was passed.
6. If there are multiple negatives, show all of them in the exception message.
7. Using TDD, Add a method to StringCalculator called `public int GetCalledCount()` that returns how many times `Add()` was invoked. Remember - Start with a failing (or even non compiling) test.
8. (.NET Only) Using TDD, Add an event to the StringCalculator class named `public event Action<string, int> AddOccured`, that is triggered after every Add() call.
Hint: Create the event declaration first, then write a failing test that listens to the event and proves it should have been triggered when calling `Add()`.
Hint 2: Example:

	string giveninput = null;
	sc.AddOccured += delegate(string input, int result) 
		 {
			giveninput = input;
		 };

9. Numbers bigger than 1000 should be ignored, for example:

		2 + 1001 == 2

10. Delimiters can be of any length with the following format:

		"//[delimiter]\n"

For example:
		
		"//[***]\n1***2***3" == 6

11. Allow multiple delimiters like this:

		"//[delim1][delim2]\n"

For example:
		
		"//[*][%]\n1*2%3" == 6

12. Make sure you can also handle multiple delimiters with length longer than one char for example:

		"//[**][%%]\n1**2%%3" == 6


## TDD Kata 2 - Interactions

https://osherove.com/tdd-kata-2/
1. Add Logging Abilities to your new String Calculator (to an ILogger.Write()) interface (you will need a mock). Every time you call Add(), the sum result will be logged to the logger.
2. When calling Add() and the logger throws an exception, the string calculator should notify an IWebservice of some kind that logging has failed with the message from the logger’s exception (you will need a mock and a stub).


## TDD Kata 3

https://osherove.com/tdd-kata-3
1. Create a Password verifications class called "PasswordVerifier".
Add the following verifications to a master function called "Verify()"
- password should be larger than 8 chars
- password should not be null
- password should have one uppercase letter at least
- password should have one lowercase letter at least
- password should have one number at least
    Each one of these should throw an exception with a different message of your choosing
2. Add feature: Password is OK if at least three of the previous conditions is true

3. Add feature: password is never OK if item 1.4 is not true.

4. Assume Each verification takes 1 second to complete. How would you solve items 2 and 3 so tests can run faster?


## TDD Kata 4: Roman numerals. 

The Kata says you should write a function to convert from normal numbers to Roman Numerals. There is no need to be able to convert numbers larger than about 3000. Write a function to convert in the other direction, ie numeral to digit.


## TDD Kata 5: Dependencies

http://codekata.com/kata/kata18-transitive-dependencies/


## TDD Kata 6: Back to the Checkout

http://codekata.com/kata/kata09-back-to-the-checkout/


