# PFFind
Searches for criteria on personal finance posts

It's currently a console application, however .net console applications do not run async code. It is intended to be used as an azure function that runs at an interval (i.e. every 2 hours). This is just a sample code

-Makes async calls to json file to check posts. It's inteded to be used at an interval to check posts

-Ignores moderator posts. Only checks ones posted by users
