CSLA Object Generator Version 1.0

Hi all,

I have been working on this object generator on and off for a few weeks and thought I would share it with everyone.

The generator uses CodeSmith templates on the backend and currently only creates C# objects. To create VB objects someone would just have to transfer the templates to VB. /* Templats for VB are created */

The generator allows you to create the metadata of multiple objects and save it to a project file (.xml). The metadata allows you complete control over your objects.  Objects are not constrained to one DB table.  

The sproc generator works well when you have defined foreign keys in your database.  It will generate a Search type procedure for collection objects and a normal ID type selection for non-collection objects.

/**** UPDATED COMPILE INSTRUCTIONS ****/

You will need to install CodeSmith 2.5 and make reference to the CodeSmith.Engine.
You will need the CSLA Framework.

No other libraries are necessary.

Once you have compiled the program you will need to copy the CslaGenerator.exe over to the CodeSmith 2.5 Directory.

You should now be able to run the program and test it out.  Please let me know if you have any problems.

Cole Shelton
Interworks Inc.

**********************************************************************************

Readme file updated by Miroslav Popovic.
See Updates.txt for list of all updates.

