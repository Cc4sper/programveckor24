INCLUDE globals.ink

{ yes_no == "": Go speak to our lord casper! | {yes_no == "noe": -> bye | Who are you?!}} #speaker:Alexander #portrait:alexander #layout:left
               *[*Give Info*]
               Ah yes... I see. Thanks for the information.
               Bye
               -> said("noe")
               -> END
               == bye ==
               ...
               bye? #speaker:Alexander #portrait:alexander #layout:left
               -> END
               === said(yesno) ===
               ~ yes_no = yesno

               -> END