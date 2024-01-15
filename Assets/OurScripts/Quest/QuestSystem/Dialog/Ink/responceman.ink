INCLUDE globals.ink

{ yes_no == "": Go speak to our lord casper! | Who are you?! } #speaker:Alexander #portrait:alexander #layout:left
               +[*Give Info*]
               Ah yes... I see. Thanks for the information.
                Bye
               -> said("noe")
               
               === said(yesno) ===
               ~ yes_no = yesno
               ... bye?
               -> END