# PersonalRecord
This project is a sample project designed to keep track of people and their favorite colors. It will function in the context of a console application and a web API. Additionally, this is a project designed to show how Web API works in a simple, clean way.


A few notes:


- In the test suite it appeared that every once in a while the TestPersonalRecOpsGenderFalse method would sometimes return that it failed instead of passing when running the entire suite. When you run the test on its own it passes.

- I completely isolated the WEB API portion from the command line application even though they share similar implementations.

- I chose .net core 2.2 but this appeared to cause some odd imcompatibilties in Nuget. Note: I was us VS for the Mac.



