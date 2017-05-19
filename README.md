RBRCIT - RBR Car Installation Tool for RBR 1.02 SSE
===================================================================

This tool allows you to easily install new cars (and their NGP physics)
before starting the game. It works with a carList.ini file maintained 
by WorkerBee, which can be updated from the tool with just a click.
This file serves as the internal "database" of vehicles.
The vehicle model and NGP Physics of each vehicle in this list 
can be downloaded with just a click.

Usage:
- On startup the tool reads the currently installed cars and 
  shows them in the right panel in gray color. Any change you make 
  will be displayed in black. The "Apply" button will be enabled only 
  if there is at least one change (one black line) in the right panel.
- Choose cars from the list on the left and add them to one of the 
  8 game slots in the right panel with a double click in the row or 
  click on the (right) arrow button.
  *** You can only add vehicles that you have both the model and physics.
- Remove a car from the right panel with either a double click in 
  the row or a click on the (left) arrow button.
- Change the engine sound by either clicking in the "Sound" column of 
  the vehicle or clicking the "Settings" button.
  *** In order for this to work, the "audio.dat" file needs to be 
  ectracted into an "Audio" subfolder. This tool can do that 
  for you: on startup the tool will check if this subfolder exist and 
  if not, it will ask you to extract it.
- In the "Settings" (cog button) of a car you can hide parts 
  i.e. Steering Wheel, Wipers or the windshield. This is a per-car 
  setting and will be remembered for the specific car. If you want to 
  always hide some parts, there are parameters in RBRCIT.ini for that.
- When done, hit "Apply".

Check the "Tools" and "Downloads" menus for 
 - updating the carList.ini file
 - downloading missing physics (especially after cars have been 
   added to the carList.ini)
 - Backup & Restore
 - Restoring the original RBR cars

 
 SPECIAL THANKS TO:
 - Workerbee (for his invaluable support and testing, and all the great past work!!!)
 - kegetys (for the dattool)
