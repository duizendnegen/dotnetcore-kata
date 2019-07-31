# Gilded Rose Requirements Specification

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods.
Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We
have a system in place that updates our inventory for us.

# Running Gilded Rose

Gilded Rose needs .NET Core 2.1 to run. To install this, go to https://dotnet.microsoft.com/download/dotnet-core/2.1

From then on, you can run the application with `dotnet run` and execute the tests with `dotnet test`.
Is Docker your favourite flavour of ice cream? `docker-compose up --build` runs the application, and `docker-compose -f .\docker-compose.test.yml up --build` runs tests.
