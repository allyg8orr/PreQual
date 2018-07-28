# PreQual
Pre-Qualification ASP.NET Core MVC App

Instructions:

NOTE: THIS ONLY WORKS WITH VISUAL STUDIO 2017 AND .NET CORE 2.1 SDK (OR LATER) INSTALLED. THIS WILL NOT WORK WITH VISUAL STUDIO 2015.
 - Open in VS2017
 - Go to Tools > NuGet Package Manager > Package Manager Console
 - Type in these commands to create the database:
 
    Add-Migration Initial
    
    Update-Database
 - Hit F5 and it should run!

You enter a Forename, Surname, Date of Birth and Annual Income. 
Hit submit and it should tell you what type of credit card you're viable for. 
If you're over 18 and earn over £30k annually, you should get a Barclaycard, if £30k and under then a Vanquis card. 
If you're under 18, it will tell you you're not viable for a credit card.
You can view the customer list and the results they've got.
Obviously this would not be in a comercially released project, but of the sake of this small brief I've included it.

Thanks!
