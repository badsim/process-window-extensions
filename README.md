## .NET ProcessWindowExtensions
A library that adds window's related extension methods to Process class.

### The Idea
Sometimes we have to do something with our os' windows like arrange, minimize, resize, switch between, force topmost or move them across virtual desktops. And if you want to manipulate them automatically with the usage of some programming language you would probably end up with Win32 API calls, copying&pasting lots of fairly low-level code to achieve conceptually simple things. 

I've created this project because one day I decided to automate the process of setting up my work environment. I noticed that I'm constantly doing the same things when I switch between projects for my clients. In one of them, I have 3 separate web-based systems which communicate with each other. To be efficient and don't waste time I have to switch between multiple VSCode and browser instances. Spawning applications and putting them in proper place takes time and can be frustrating, especially when you have to arrange them on 2 displays multiplied by 3 virtual desktops. 

For me a natural way to manipulate windows is via Process class. Just take a look at:

```
var pathToVSCode = @"C:\Users\badsim\AppData\Local\Programs\Microsoft VS Code\Code.exe";
var pathToChrome = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
Process.Start(pathToVSCode).MoveToVirtualDesktop(2).MoveToDisplay(0).Maximize();
Process.Start(pathToChrome).MoveToVirtualDesktop(2).MoveToDisplay(1).Maximize();
```

Wouldn't be nice to have that in dotnet script *.csx files and be able to prepare our work environment faster? 

Of course, there is plenty of other usages for that.

### Usage

Note that the library will work ONLY on Windows 10 and IT MAY crash on some previous and future os versions. I've built and test it on Windows Pro v1909.

Coming soon.


### Research & References [Virtual Desktops]
Managing Virtual Desktops isn't that easy as it requires COM objects to work. During my research, I used some knowledge and code from: 
https://github.com/Grabacr07/VirtualDesktop
https://github.com/MScholtes/VirtualDesktop
https://github.com/mzomparelli/zVirtualDesktop 
https://github.com/Ciantic/VirtualDesktopAccessor 
https://social.msdn.microsoft.com/Forums/vstudio/en-US/fd52fc39-d1f3-4da8-8b68-debceab75ffd/requesting-api-calls-for-windows-10s-virtual-desktops
https://www.cyberforum.ru/blogs/105416/blog3671.html 
https://www.cyberforum.ru/blogs/105416/blog3605.html

You did a great job with your work, thank you!


### Further research
If you want to dig into the COM interfaces here are some steps to start with:
1. Download and install Windows SDK https://developer.microsoft.com/pl-pl/windows/downloads/sdk-archive/ 
2. Download a decent grep like tool, I prefer to use AstroGrep -> http://astrogrep.sourceforge.net/ 
3. Set search directory to -> C:\Program Files (x86)\Windows Kits\10\Include\
4. Search for classes for instance try "VirtualDesktopManager", it should point to the ShObjIdl.idl file containing some class ids. 
5. Explore and have fun :) 

