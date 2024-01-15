INCLUDE globals.ink

{ yes_no == "": -> main | {yes_no == "yes": -> already_yes_no |{yes_no == "naa": -> aa | -> afterQuest }}}


=== main ===
Hello there! #speaker:Casper #portrait:casper_angry #layout:left
This is my game idea! <color=\#FF1E35>Clash of Casper: Casper Rider!</color> What do you think?  #portrait:casper_neutral #layout:left
+ [Pretty Good]
    Good... #portrait:casper_funny
+ [Not so good.]
    Well, your opinion does not matter anyway. #portrait:casper_angry
    
- Casper... Be nice to your employees. #speaker:Alexander #portrait:alexander #layout:right

No, I don't think I will. Would you like to hear my game idea again? #speaker:Casper #portrait:casper_neutral #layout:right
+ [Yes]
  //  -> main
+ [No]
    
    -Give that person information. Do you <color=\#32CD32>accept</color> this quest????
+ [Accept]
   -> said("yes")
+ [Decline]
  Oh... come back later then....
  -> END
  
=== said(yesno) ===
~ yes_no = yesno
Thanks! Good luck!
-> END

== already_yes_no ==
Go away peasant! You've already answered {yes_no}. Please do your mission! #speaker:Casper #portrait:casper_neutral #layout:right
-> END
== afterQuest ==
Thank you! You get..........
Nothing
-> END
-> said("nooooo")

== aa ==
    -You're back... Do you accept now????
+ [Accept]
   -> said("yes")
+ [Decline]
  Oh... come back later then...
  -> END










