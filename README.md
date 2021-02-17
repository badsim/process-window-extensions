## .NET ProcessWindowExtensions
A library which adds window's related features to Process class. Basically a set of useful extension methods. 

### The Idea
Sometimes we have to do something with our os' windows like arrange, minimize, resize, switch between, force topmost or move them across virtual desktops. And if you want to manipulate them automatically with usage of some programming language you would propably end up with Win32 api calls, copying&pasting a lots of fairly low level code to achieve conceptually simple things. 

I've created this project because one day I decided to automate process of setting up my work environment. I noticed that I'm constantly doing the same things when I swich between projects for my clients. In one of them I have 3 separate web-based systems which communicate with each other. To be efficient and don't waste time I have to switch between multiple VSCode and browser instances. Spawning applications and putting them in proper place takes time and can be frustrating, especially when you have to arrange them on 2 displays multiplied by 3 virtual desktops. 

For me a natural way to manipulate windows is via Process class. Just take a look at:

```
var pathToVSCode = @"C:\Users\badsim\AppData\Local\Programs\Microsoft VS Code\Code.exe";
var pathToChrome = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
Process.Start(pathToVSCode).MoveToVirtualDesktop(2).MoveToDisplay(0).Maximize();
Process.Start(pathToChrome).MoveToVirtualDesktop(2).MoveToDisplay(1).Maximize();
```

Wouldn't be a nice to have that in dotnet script *.csx files and be able to prepare our work environment really fast? 

Of course there is plenty of other usages for that. 

### Examples

Soon. 


