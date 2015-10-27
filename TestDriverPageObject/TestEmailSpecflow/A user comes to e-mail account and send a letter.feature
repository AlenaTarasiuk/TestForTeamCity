Feature: A user comes to e-mail account and send a letter
		As a user to create a mailbox
		When I come on mail, I create a letter, save, send and go out to the mailbox
		Then I expect that the letter will be created, stored correctly and sent successfully

Background: 
	Given I navigate on mailbox page

Scenario: The user comes in email account
	 When I go to created a mailbox
	 Then I check that entry carried out successfully
	 When I out of mailbox

Scenario: A user comes to e-mail account and send a letter
	 When I go to created a mailbox
	 When I create a new message with data destination "testuser.2016@mail.ru", topic "message" and data content "Hello!"
	  And I move to the folder Drafts
	 When I open letter
	 Then I check the contents of the letter data destination "testuser.2016@mail.ru" and data content "Hello!"
	 When I send letter
	  And I move to the list of messages in the folder Drafts
	 Then I check that the letter disappeared
	 When I move to the folder Sent
	 Then I check that the letter is in the list
	 When I out of mailbox

Scenario: The user logout with email account
	 When I go to created a mailbox
	 When I out of mailbox
	 Then I check that logout made successfully










