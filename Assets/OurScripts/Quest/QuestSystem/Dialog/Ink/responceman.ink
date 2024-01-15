INCLUDE globals.ink

{ yes_no == "": Go speak to our lord casper! | Who are you?! } #speaker:Alexander #portrait:alexander #layout:left
               +[*Give Info*]
               -> said("noe")
               
               === said(yesno) ===
               ~ yes_no = yesno
                 Ah yes... I see. Thanks for the information.
                 Bye
               -> END