INCLUDE globals.ink

{ yes_no == "": -> main | -> already_yes_no }


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
    -> main
+ [No]
    
    -I see... Do you like your pay?
+ [Yes]
   -> said("Yes")
+ [No]
   -> said("No")
=== said(yesno) ===
~ yes_no = yesno
You said {yesno}!
-> END

== already_yes_no ==
Go away peasant! You've already answered {yes_no}
-> END