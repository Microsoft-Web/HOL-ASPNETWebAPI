#Build RESTful API's with ASP.NET Web API#

## Overview ##

In recent years, it has become clear that HTTP is not just for serving up HTML pages. It is also a powerful platform for building Web APIs, using a handful of verbs (GET, POST, and so forth) plus a few simple concepts such as _URIs_ and _headers_.
ASP.NET Web API is a set of components that simplify HTTP programming. Because it is built on top of the ASP.NET MVC runtime, Web API automatically handles the low-level transport details of HTTP. At the same time, Web API naturally exposes the HTTP programming model. In fact, one goal of Web API is to _not_ abstract away the reality of HTTP. As a result, Web API is both flexible and easy to extend. 
In this hands-on lab, you will use Web API to build a simple REST API for a contact manager application. You will also build a client to consume the API.
The REST architectural style has proven to be an effective way to leverage HTTP - although it is certainly not the only valid approach to HTTP. The contact manager will expose the following RESTful methods.
This lab requires a basic understanding of HTTP, REST, and assumes you have a basic working knowledge of HTML, JavaScript, and jQuery.

> **Note:** The ASP.NET Web site has an area dedicated to the ASP.NET Web API framework at [http://asp.net/web-api](http://asp.net/web-api). This site will continue to provide late-breaking information, samples, and news related to Web API, so check it frequently if you'd like to delve deeper into the art of creating custom Web API's available to virtually any device or development framework.

### Objectives ###

In this hands-on lab, you will learn how to:

- Implement a RESTful Web API

- Call the API from an HTML client

- Use the Microsoft Managed Extensibility Framework (MEF 2.0) to create a loosely-coupled and reusable componentized architecture

 
### Prerequisites ###

The following is required to complete this hands-on lab:

- [Microsoft Visual Studio 11 Beta](http://www.microsoft.com/visualstudio/11/)

- Windows PowerShell (for setup scripts - already installed on Windows 7 and Windows Server 2008 R2)

 
### Setup ###

Throughout the lab document, you will be instructed to insert code blocks. For your convenience, most of that code is provided as Visual Studio Code Snippets, which you can use from within Visual Studio to avoid having to add it manually.

To install the code snippets:

1. Open a Windows Explorer window and browse to the lab's **Source\Setup** folder.

1. Double-click the **Setup.cmd** file in this folder to install the Visual Studio code snippets.

 
### Using the Code Snippets ###

With code snippets, you have all the code you need at your fingertips. The lab document will tell you exactly when you can use them, as shown in the following figure.

 ![Using Visual Studio code snippets to insert code into your project](./images/Using-Visual-Studio-code-snippets-to-insert-code-into-your-project.png?raw=true "Using Visual Studio code snippets to insert code into your project")
 
_Using Visual Studio code snippets to insert code into your project_

_**To add a code snippet using the keyboard (C# only)**_
1. Place the cursor where you would like to insert the code.

1. Start typing the snippet name (without spaces or hyphens).

1. Watch as IntelliSense displays matching snippets' names.

1. Select the correct snippet (or keep typing until the entire snippet's name is selected).

1. Press the Tab key twice to insert the snippet at the cursor location.

 
   ![Start typing the snippet name](./images/Start-typing-the-snippet-name.png?raw=true "Start typing the snippet name")
 
_Start typing the snippet name_

   ![Press Tab to select the highlighted snippet](./images/Press-Tab-to-select-the-highlighted-snippet.png?raw=true "Press Tab to select the highlighted snippet")
 
_Press Tab to select the highlighted snippet_

   ![Press Tab again and the snippet will expand](./images/Press-Tab-again-and-the-snippet-will-expand.png?raw=true "Press Tab again and the snippet will expand")
 
_Press Tab again and the snippet will expand_

_**To add a code snippet using the mouse (C# and XML)**_
1. Right-click where you want to insert the code snippet.

1. **Select Insert Snippet** followed by **My Code Snippets**.

1. Pick the relevant snippet from the list, by clicking on it.

 
  ![Right-click where you want to insert the code snippet and select Insert Snippet](./images/Right-click-where-you-want-to-insert-the-code-snippet-and-select-Insert-Snippet.png?raw=true "Right-click where you want to insert the code snippet and select Insert Snippet")
 
_Right-click where you want to insert the code snippet and select Insert Snippet_

 ![Pick the relevant snippet from the list, by clicking on it](./images/Pick-the-relevant-snippet-from-the-list,-by-clicking-on-it.png?raw=true "Pick the relevant snippet from the list, by clicking on it")
 
_Pick the relevant snippet from the list, by clicking on it_

## Exercises ##

This hands-on lab includes the following exercise:

1. Create a Read-Only Web API

1. Extend the Read-Only Web API so that it persists data

1. Consume the Web API from an HTML Client

 
Estimated time to complete this lab: 60 minutes.

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Every predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this lab describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in these procedures that you need to take into account. 

### Exercise 1: Create a Read-Only Web API ###

In this exercise, you will implement the read-only GET methods for the contact manager.

#### Task 1 - Creating the API Project ####

In this task, you will use the new ASP.NET web project templates to create a Web API web application.

1. Run Visual Studio 11.

1. From the **File** menu, select **New Project**. Select the **Visual C# | Web** project type from the project type tree view, then select the **ASP.NET MVC 4 Web Application** project type. Name the project **ContactManager** and then click OK.

 	![Creating a new MVC 4.0 Web Application Project](./images/Creating-a-new-MVC-4.0-Web-Application-Project.png?raw=true "Creating a new MVC 4.0 Web Application Project")
 
	_Creating a new MVC 4.0 Web Application Project_

1. In the ASP.NET MVC 4 project type dialog, select the **Web API** project type. Click OK.

 	![Specifying the Web API project type](./images/Specifying-the-Web-API-project-type.png?raw=true "Specifying the Web API project type")
 
 	_Specifying the Web API project type_
 
#### Task 2 - Creating the Contact Manager API Controllers ####

In this task, you will create the controller classes in which API methods will reside.

1. Delete the file named**ValuesController.cs** from the project.

1. Right-click the **Controllers** folder in the project and select **Add | Controller** from the context menu.

 	![Adding a new controller to the project](./images/Adding-a-new-controller-to-the-project.png?raw=true "Adding a new controller to the project")
 
	_Adding a new controller to the project_

1. In the **Add Controller** dialog that appears, select **Empty API Controller** from the Template menu. Name the controller class **ContactController**. Then, click **Add.**

 	![Using the Add Controller dialog to create a new Web API controller](./images/Using-the-Add-Controller-dialog-to-create-a-new-Web-API-controller.png?raw=true "Using the Add Controller dialog to create a new Web API controller")
 
	_Using the Add Controller dialog to create a new Web API controller_

1. Add the code below to the **ContactController.**

	(Code Snippet - _Web API Lab - Ex01 - Get API Method_)

	````C#

	public string[] Get()
	{
	    return new string[]
	    {
	        "Hello",
	        "World"
	    };
	}
	````

1. Press **F5** to debug the application. The default home page for a Web API project should appear.

 	![The default home page of an ASP.NET Web API application](./images/The-default-home-page-of-an-ASP.NET-Web-API-application.png?raw=true "The default home page of an ASP.NET Web API application")
 
	_The default home page of an ASP.NET Web API application_

1. Press the F12 key to open the Developer Tools window. Click the **Network** tab, and then click the **Start Capturing** button to begin capturing network traffic into the window.

 	![Opening the network tab and initiating network capture](./images/Opening-the-network-tab-and-initiating-network-capture.png?raw=true "Opening the network tab and initiating network capture")
 
	_Opening the network tab and initiating network capture_

1. Append the URL in the browser's address bar with **/api/contact** and press enter. The transmission details will appear in the network capture window. Note that the response's MIME type is **application/json**. This demonstrates how the default output format is JSON.

 	![Viewing the output of the Web API request in the Network view](./images/Viewing-the-output-of-the-Web-API-request-in-the-Network-view.png?raw=true "Viewing the output of the Web API request in the Network view")
 
	_Viewing the output of the Web API request in the Network view_

	> **Note:** Internet Explorer 9's default behavior at this point will be to ask if the user would like to save or open the stream resulting from the Web API call. The output will be a text file containing the JSON result of the Web API URL call. Press the cancel button unless you want to see the text contents of the output. 

1. Click the **Go to detailed view** button to see more details about the response of this API call, then click the **Response body** tab to view the actual JSON response text.

 	![Viewing the JSON output text in the network monitor](./images/Viewing-the-JSON-output-text-in-the-network-monitor.png?raw=true "Viewing the JSON output text in the network monitor")
 
 	_Viewing the JSON output text in the network monitor_
 
#### Task 3 - Creating the Contact Models and Augment the Contact Controller ####

In this task, you will create the controller classes in which API methods will reside.

1. Right-click the **Models** folder and select **Add | New Item** from the context menu.

 	![Adding a new model to the web application](./images/Adding-a-new-model-to-the-web-application.png?raw=true "Adding a new model to the web application")
 
	_Adding a new model to the web application_

1. In the **Add New Item** dialog, name the new file **Contact.cs** and click **Add.**

 	![Creating the new Contact class file](./images/Creating-the-new-Contact-class-file.png?raw=true "Creating the new Contact class file")
 
	_Creating the new Contact class file_

1. Add the following code to the Contact class.

	(Code Snippet - _Web API Lab - Ex01 - Get API Method_)

	````C#
	public class Contact
	{
	    public int Id { get; set; }
	    public string Name { get; set; }
	}
	````

1. In the **ContactController** class, select the word **string** in method definition of the Get method, and type the word **Contact**. Once the word is typed in, an indicator will appear at the beginning of the word _Contact_. Either hold down the Ctrl key and press the period (.) key or click the icon using your mouse to open up the assistance dialog in the code editor, to automatically fill in the **using** directive for the Models namespace.

 	_Using Intellisense assistance for namespace declarations_

1. Modify the code for the **Get** method so that it returns an array of Contact model instances.

	(Code Snippet - _Web API Lab - Ex01 - Returning a list of contacts_)

	````C#
	public Contact[] Get()
	{
	    return new Contact[]
	    {
	        new Contact
	        {
	            Id = 1,
	            Name = "Glenn Block"
	        },
	        new Contact
	        {
	            Id = 2,
	            Name = "Dan Roth"
	        }
	    };
	}
	````

1. Press **F5** to debug the web application in the browser. To view the changes made to the response output of the API, perform the following steps.

	<ol type="a">
<li>Once the browser opens, press F12 to re-open the developer tools.</li>
<li>Click the <b>Network</b> tab.</li>
<li>Press the <b>Start Capturing</b> button.</li>
<li>Add the URL suffix <b>/api/contact</b> to the URL in the address bar and press the Enter key.</li>
<li>Press the <b>Go to detailed view</b> button.</li>
<li>Select the <b>Response body</b> tab. You should see a JSON string representing the serialized form of an array of Contact instances.</li>
</ol>

 	![JSON serialized output of a complex Web API method call](./images/JSON-serialized-output-of-a-complex-Web-API-method-call.png?raw=true "JSON serialized output of a complex Web API method call")
 
 	_JSON serialized output of a complex Web API method call_
 
#### Task 4 - Extracting Functionality into a Service Layer and Injecting it Using MEF 2.0 ####

This task will demonstrate how the Microsoft Managed Extensibility Framework (MEF) can provide more separation between controller logic and the services that offer functionality to Web API. MEF 2.0, which ships with the Microsoft .NET 4.5 Framework provides Dependency Injection features and makes it easy for developers to separate their service functionality from the controller layer, thereby allowing reusability of the services that actually do the work. MEF 2.0 is available via NuGet as a free component and is accessible via the Package Manager Console in Visual Studio 11.

1. Click on the **Tools** menu and select **Library Package Manager | Package Manager Console** from the menu. The Package Manager Console window will open.

1. In the Package Manager Window, type the command **Install-Package Microsoft.Mef.MvcCompositionProvider -Prerelease** in order to pull the package from NuGet and add it to the Web API project.

 	![Adding a reference to MEF 2.0 using NuGet](./images/Adding-a-reference-to-MEF-2.0-using-NuGet.png?raw=true "Adding a reference to MEF 2.0 using NuGet")
 
	_Adding a reference to MEF 2.0 using NuGet_

1. A new folder will be added to the project during the MEF package install process. The **Parts** folder's purpose is to contain any custom service interfaces and implementations required by the Web API application to function. Within the folder will be a new file by default, named **Part1.cs.** Delete this file, as it won't be used by the Web API application.

 	![The MEF 2.0 Parts folder, which should contain service interfaces and implementations](./images/The-MEF-2.0-Parts-folder,-which-should-contain-service-interfaces-and-implementations.png?raw=true "The MEF 2.0 Parts folder, which should contain service interfaces and implementations")
 
	_The MEF 2.0 Parts folder, which should contain service interfaces and implementations_

1. Right-click the **Parts** folder and select **Add | Class** from the context menu.

 	![Adding a new class to the Parts folder](./images/Adding-a-new-class-to-the-Parts-folder.png?raw=true "Adding a new class to the Parts folder")
 
	_Adding a new class to the Parts folder_

1. When the **Specify Name for Item** dialog appears, name the new class **ContactRepository** and click **OK**.

 	![Creating a class file to contain the code for the Contact Repository service layer](./images/Creating-a-class-file-to-contain-the-code-for-the-Contact-Repository-service-layer.png?raw=true "Creating a class file to contain the code for the Contact Repository service layer")
 
	_Creating a class file to contain the code for the Contact Repository service layer_

1. Add a using directive to the **ContactRepository.cs** file to include the models namespace.

	````C#
	using ContactManager.Models;
	````

1. Add the following code to the **ContactRepository.cs** file to implement the contact repository interface and implementation class.

	(Code Snippet - _Web API Lab - Ex01 - Contact Repository_)

	````C#
	public interface IContactRepository
	{
	    Contact[] GetAllContacts();
	}
	 
	public class ContactRepository : IContactRepository
	{
	    public Contact[] GetAllContacts()
	    {
	        return new Contact[]
	            {
	                new Contact
	                {
	                    Id = 1,
	                    Name = "Glenn Block"
	                },
	                new Contact
	                {
	                    Id = 2,
	                    Name = "Dan Roth"
	                }
	            };
	    }
	}
	````

	> **Note:** The interface and class could be separated into separate files if preferred.

1. Change the **HomeController.cs** code so that it supports constructor injection and add a private field to represent the instance supplied at construction, so that the rest of the class members can make use of the service implementation.

	(Code Snippet - _Web API Lab - Ex01 - Contact Repository Implementation_)

	````C#
	private IContactRepository _contactRepository;
	 
	public HomeController(IContactRepository contactRepo)
	{
	    _contactRepository = contactRepo;
	}
	````

1. Put a breakpoint on the constructor of the **HomeController** class. Press F5 to begin a debugging session and note that the breakpoint is hit and an instance of the **ContactRepository** class has been passed to it.

 	![The HomeController when passed a service instance via Dependency Injection](./images/The-HomeController-when-passed-a-service-instance-via-Dependency-Injection.png?raw=true "The HomeController when passed a service instance via Dependency Injection")
 
	_The HomeController when passed a service instance via Dependency Injection_

1. Add a reference to **System.Reflection.Context** to the project.

 	![Adding a reference](./images/Adding-a-reference.png?raw=true "Adding a reference")
 
	_Adding a reference_

1. Open the **Global.asax.cs** file in Visual Studio 11 if it is not already open in the IDE.

1. Add the following namespaces to the list of namespaces already included in the file.

	(Code Snippet - _Web API Lab - Ex01 - Namespaces for MEF_)

	````C#
	using System.ComponentModel.Composition.Lightweight.Hosting;
	using System.ComponentModel.Composition.Registration;
	using System.ComponentModel.Composition.Web.Mvc;
	````

1. Replace the **Application_Start** method with the following code. This code configures the MEF 2.0 runtime so that all controller classes - both standard MVC controllers _and_ Web API controllers - can use the same MEF service injection functionality.

	(Code Snippet - _Web API Lab - Ex01 - Global MEF Wireup_)

	````C#
	protected void Application_Start()
	{
	    AreaRegistration.RegisterAllAreas();
	 
	    RegisterGlobalFilters(GlobalFilters.Filters);
	    RegisterRoutes(RouteTable.Routes);
	 
	 var conventions = new RegistrationBuilder ();
	 conventions.ForTypesDerivedFrom<IController>().Export();
	 conventions.ForTypesDerivedFrom<ApiController>().Export();
	 
	 conventions
	    .ForTypesMatching((t) => 
	        t.Namespace != null && 
	            (t.Namespace.Contains(".Parts.") || 
	                t.Namespace.EndsWith("Parts")))
	        .Export()
	        .ExportInterfaces();
	 
	 CompositionProvider.SetConfiguration(
	     new ContainerConfiguration()
	        .WithAssembly(typeof(WebApiApplication).Assembly, conventions)
	     );
	 
	GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
	     t => DependencyResolver.Current.GetService(t),
	     t => DependencyResolver.Current.GetServices(t)
	     );
	}
	````

	> **Note:** This step is necessary at the time of the Visual Studio 11 beta release. Future releases will probably enhance automatic support for Web API and reduce the code required to wire MEF 2.0 up to those controllers.

1. Open the **ContactController.cs** file if it is not already open.

1. Add the following using statement to the namespace declaration section of the file.

	````C#
	using ContactManager.Parts;
	````

1. Change the **ContactController.cs** code so that it supports constructor injection and add a private field to represent the instance supplied at construction, so that the rest of the class members can make use of the service implementation already in use by the HomeController class.

	(Code Snippet - _Web API Lab - Ex01 - Contact Controller_)

	````C#
	C#
	public class ContactController : ApiController
	{
	    private IContactRepository _contactRepository;
	 
	    public ContactController(IContactRepository contactRepo)
	    {
	        _contactRepository = contactRepo;
	    }     
	}
	````

1. Change the **Get** method so that it makes use of the contact repository service.

	(Code Snippet - _Web API Lab - Ex01 - Returning a list of contacts via the repository_)

	````C#
	C#
	public Contact[] Get()
	{
	    return _contactRepository.GetAllContacts();
	}
	````

1. Put a breakpoint on the **ContactController's** constructor, and on the **Get** method definition.

 	![Adding breakpoints to the contact controller](./images/Adding-breakpoints-to-the-contact-controller.png?raw=true "Adding breakpoints to the contact controller")
 
	_Adding breakpoints to the contact controller_

1. Press F5 to run the application.

1. When the browser opens, press F12 to open the developer tools.

1. Click the **Network** tab.

1. Click the **Start Capturing** button.

1. Append the URL in the address bar with the suffix **/api/contact** and press the Enter key to load the API controller.

1. Visual Studio 11 should break at the constructor.

 	![Breaking at the constructor of the contact controller during debug](./images/Breaking-at-the-constructor-of-the-contact-controller-during-debug.png?raw=true "Breaking at the constructor of the contact controller during debug")
 
		_Breaking at the constructor of the contact controller during debug_

1. Press F5 to continue execution. Visual Studio 11 should break again, this time as the Get controller method begins execution.

 	![Breaking within the Get method](./images/Breaking-within-the-Get-method.png?raw=true "Breaking within the Get method")
 
	_Breaking within the Get method_

1. Press F5 to continue.

1. Go back to Internet Explorer if it is not already in focus. Note the network capture window.

 	![Network view in Internet Explorer showing results of the Web API call](./images/Network-view-in-Internet-Explorer-showing-results-of-the-Web-API-call.png?raw=true "Network view in Internet Explorer showing results of the Web API call")
 
	_Network view in Internet Explorer showing results of the Web API call_

1. Click the Go to detailed view button.

1. Click the **Response body** tab. Note the JSON output of the API call, and how it represents the two contacts retrieved by the service layer.

 	![Viewing the JSON output from the Web API in the developer tools window](./images/Viewing-the-JSON-output-from-the-Web-API-in-the-developer-tools-window.png?raw=true "Viewing the JSON output from the Web API in the developer tools window")
 
 	_Viewing the JSON output from the Web API in the developer tools window_
 
### Exercise 2: Create a Read/Write Web API ###

In this exercise, you will implement POST, PUT, and DELETE methods for the contact manager to enable it with data-editing features.

#### Task 1 - Opening the Web API Project ####

In this task, you will prepare to enhance the Web API project created in Exercise 1 so that it can accept user input.

1. Open Visual Studio 11 if it is not already running.

1. Open the project created in Exercise 1, or open the project in the **Source/CS/Ex02/Begin/ContactManager** folder that accompanied this lab.

1. Open the **Parts/ContactRepository.cs** file.

 
#### Task 2 - Adding Data-Persistence Features to the Contact Repository Implementation ####

In this task, you will augment the ContactRepository class of the Web API project created in Exercise 1 so that it can persist and accept user input and new Contact instances.

1. Add the following constant to the class to represent the name of the web server cache item key name later in this exercise.

	````C#
	C#
	const string cacheKey = "ContactStore";
	````

1. Add a constructor to the ContactRepository containing the following code.

	(Code Snippet - _Web API Lab - Ex02 - Contact Repository Constructor_)

	````C#
	C#
	public ContactRepository()
	{
	    var ctx = HttpContext.Current;
	 
	    if (ctx != null)
	    {
	        if (ctx.Cache[cacheKey] == null)
	        {
	            var contacts = new Contact[]
	            {
	                new Contact
	                {
	                    Id = 1, Name = "Glenn Block"
	                },
	                new Contact
	                {
	                    Id = 2, Name = "Dan Roth"
	                }
	            };
	 
	            ctx.Cache[cacheKey] = contacts;
	        }
	    }
	}
	````

1. Modify the code for the GetAllContacts method as demonstrated below.

	(Code Snippet - _Web API Lab - Ex02 - Get All Contacts_)

	````C#
	C#
	public Contact[] GetAllContacts()
	{
	    var ctx = HttpContext.Current;
	 
	    if (ctx != null)
	    {
	        return (Contact[])ctx.Cache[cacheKey];
	    }
	 
	    return new Contact[]
	        {
	            new Contact
	            {
	                Id = 0,
	                Name = "Placeholder"
	            }
	        };
	}
	````

	>**Note:** This example is for demonstration purposes and will use the web server's cache as a storage medium, so that the values will be available to multiple clients simultaneously, rather than use a Session storage mechanism or a Request storage lifetime. One could use Entity Framework, XML storage, or any other variety in place of the web server cache.

1. Add a new method named **SaveContact** to the **IContactRepository** interface to do the work of saving a contact. The **SaveContact** method should take a single **Contact** parameter and return a Boolean value indicating success or failure.

	(Code Snippet - _Web API Lab - Ex02 - Adding the SaveContact Method_)

	````C#
	C#
	public interface IContactRepository
	{
	    Contact[] GetAllContacts();
	    bool SaveContact(Contact contact);
	}
	````

1. Implement the **SaveContact** method in the **ContactRepository** class by adding the following code.

	(Code Snippet - _Web API Lab - Ex02 - Implementing the SaveContact Method_)

	````C#
	C#
	public bool SaveContact(Contact contact)
	{
	    var ctx = HttpContext.Current;
	 
	    if (ctx != null)
	    {
	        try
	        {
	            ((Contact[])ctx.Cache[cacheKey]).ToList().Add(contact);
	 
	            return true;
	        }
	        catch (Exception ex)
	        {
	            Console.WriteLine(ex.ToString());
	            return false;
	        }
	    }
	 
	    return false;
	}
 	````
 
### Exercise 3: Consume the Web API from an HTML Client ###

In this exercise, you will create an HTML client to call the Web API. This client will facilitate data exchange with the Web API using JavaScript and will display the results in a web browser using HTML markup.

#### Task 1 - Modifying the Index View to Provide a GUI for Displaying Contacts ####

In this task, you will modify the default Index view of the web application to support the requirement of displaying the list of existing contacts in an HTML browser.

1. Open Visual Studio 11 if it is not already open.

1. Open the **ContactManager** solution located in the **CS/Ex03/Begin/ContactManager** folder accompanying this lab.

1. Open the **Views/Home/Index.cshtml** file.

1. Add a script reference to load the jQuery JavaScript library at the top of the Index view.

	````HTML
	HTML
	<script src="@Url.Content("~/Scripts/modernizr-2.0.6-development-only.js")" type="text/javascript">
</script>
	````
1. Remove the HTML code within the **body** div element so that the page is relatively bare. 
	<!-- strike:2-13 -->
	````HTML
	HTML
	<body>
	    <header>
	        <div class="content-wrapper"> 
	            <div class="float-left">
	                <p class="site-title"><a href="/">ASP.NET Web API</a></p>
	            </div>
	        </div>
	    </header>
	    <div id="body">
	        
	    </div>
	</body>
	````

1. Add an unordered list (an HTML ul element) as a child element of the div tag. Give the unordered list an id attribute value of **contacts**.

	````HTML
	HTML
	<div id="body">
	    <ul id="contacts"></ul>
	</div>
	````

1. Add a new JavaScript code block just before the closing **head** tag of the **Index.cshtml** view. This code will perform the HTTP request to the Web API.

	````HTML
	HTML
	<script type="text/javascript">
	$(function()
	{
	    $.getJSON('/api/contact', function(contactsJsonPayload)
	    {
	        $(contactsJsonPayload).each(function(i, item)
	        {
	            $('#contacts').append('<li>' + item.Name + '</li>');
	        });
	    });
	});
	</script>
	````

1. Open the **ContactController.cs** file if it is not already open.

1. Place a breakpoint on the **Get** method of the **ContactController** class.

 	![Placing a breakpoint on the Get method of the API controller](./images/Placing-a-breakpoint-on-the-Get-method-of-the-API-controller.png?raw=true "Placing a breakpoint on the Get method of the API controller")
 
	_Placing a breakpoint on the Get method of the API controller_

1. Press the F5 key to run the project. The browser will load the HTML document.

1. Once the page loads and the JavaScript executes, the breakpoint will be hit and the code execution will pause in the controller.

 	![Debugging into the Web API call using Visual Studio 11](./images/Debugging-into-the-Web-API-call-using-Visual-Studio-11.png?raw=true "Debugging into the Web API call using Visual Studio 11")
 
	_Debugging into the Web API call using Visual Studio 11_

1. Press F5 or the debugging toolbar's **Continue** button to continue loading the view in the browser. Once the Web API call completes you should see the contacts returned from the Web API call displayed as list items in the browser.

 	![Results of the API call displayed in the browser as list items](./images/Results-of-the-API-call-displayed-in-the-browser-as-list-items.png?raw=true "Results of the API call displayed in the browser as list items")
 
 	_Results of the API call displayed in the browser as list items_
 
#### Task 2 - Modifying the Index View to Provide a GUI for Creating Contacts ####

In this task, you will continue to modify the Index view of the MVC application. A form will be added to the HTML page that will capture user input and send it to the Web API to create a new Contact, and a new Web API controller method will be created to collect date from the GUI.

1. Open the **ContactController.cs** file in Visual Studio 11 if it is not already open.

1. Add a new method to the controller class named **Post** as demonstrated in the following code.

	(Code Snippet - _Web API Lab - Ex03 - Post Method_)

	````C#
	C#
	public HttpResponseMessage<Contact> Post(Contact contact)
	{
	    this._contactRepository.SaveContact(contact);
	 
	    var response = new HttpResponseMessage<Contact>(contact)
	        {
	            StatusCode = System.Net.HttpStatusCode.Created
	        };
	 
	    return response;
	}
	````

1. Open the **Index.cshtml** file in Visual Studio if it is not already open.

1. Add the HTML code below to the file just after the unordered list you added in the previous task.

	````HTML
	HTML
	<form id="saveContactForm" method="post">
	<h3>Create a new Contact</h3>
	<p>
	    <label for="contactId">Contact Id:</label>
	    <input type="text" name="Id" />
	</p>
	<p>
	    <label for="contactName">Contact Name:</label>
	    <input type="text" name="Name" />
	</p>
	<input type="button" id="saveContact" value="Save" />
	</form>
	````

1. Within the script element in the document's head, add the following code to handle button-click events, which will post the data to the Web API using an HTTP POST call.

	
	````JavaScript
	HTML
	$('#saveContact').click(function()
	    {
	        var nm = $('#contactName').val();
	        var id = $('#contactId').val();
	 
	        $.post("api/contact",
	            $("#saveContactForm").serialize(),
	            function(value)
	            {
	                $('#contacts').append('<li>' + value.Name + '</li>');
	            },
	            "json"
	        );
	    });
	````

1. In **ContactController.cs**, place a breakpoint on the **Post** method.

1. Press the F5 key to run the application in the browser.

1. Once the page is loaded in the browser, type in a new contact name and Id and click the **Save** button.

 	![The client HTML document loaded in the browser](./images/The-client-HTML-document-loaded-in-the-browser.png?raw=true "The client HTML document loaded in the browser")
 
	_The client HTML document loaded in the browser_

1. When the debugger window breaks in the **Post** method, take a look at the properties of the **contact** parameter. The values should match the data you entered in the form.

 	![The Contact object being sent to the Web API from the client](./images/The-Contact-object-being-sent-to-the-Web-API-from-the-client.png?raw=true "The Contact object being sent to the Web API from the client")
 
	_The Contact object being sent to the Web API from the client_

1. Step through the method in the debugger until the **response** variable has been created. Upon inspection in the **Locals** window in the debugger, you'll see that all the properties have been set.

 	![The response following creation in the debugger](./images/The-response-following-creation-in-the-debugger.png?raw=true "The response following creation in the debugger")
 
	_The response following creation in the debugger_

1. If you press **F5** or click **Continue** in the debugger the request will complete. Once you switch back to the browser, the new contact has been added to the list of contacts stored by the **ContactRepository** implementation.

 	![The browser reflects successful creation of the new contact instance](./images/The-browser-reflects-successful-creation-of-the-new-contact-instance.png?raw=true "The browser reflects successful creation of the new contact instance")
 
	_The browser reflects successful creation of the new contact instance_

 
## Summary ##

This lab has introduced you to the new ASP.NET Web API framework and to the implementation of RESTful Web API's using the framework. From here, you could create a new repository that facilitates data persistence using any number of mechanisms and wire that service up rather than the simple one provided as an example in this lab. Web API supports a number of additional features, such as enabling communication from non-HTML clients written in any language that supports HTTP and JSON or XML. The ability to host a Web API outside of a typical web application is also possible, as well as is the ability to create your own serialization formats.

The ASP.NET Web site has an area dedicated to the ASP.NET Web API framework at [http://asp.net/web-api](http://asp.net/web-api). This site will continue to provide late-breaking information, samples, and news related to Web API, so check it frequently if you'd like to delve deeper into the art of creating custom Web API's available to virtually any device or development framework.