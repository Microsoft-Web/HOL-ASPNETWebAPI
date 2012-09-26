#Build RESTful API's with ASP.NET Web API#
<a name="Overview" />
## Overview ##

In recent years, it has become clear that HTTP is not just for serving up HTML pages. It is also a powerful platform for building Web APIs, using a handful of verbs (GET, POST, and so forth) plus a few simple concepts such as _URIs_ and _headers_.
ASP.NET Web API is a set of components that simplify HTTP programming. Because it is built on top of the ASP.NET MVC runtime, Web API automatically handles the low-level transport details of HTTP. At the same time, Web API naturally exposes the HTTP programming model. In fact, one goal of Web API is to _not_ abstract away the reality of HTTP. As a result, Web API is both flexible and easy to extend. 
In this hands-on lab, you will use Web API to build a simple REST API for a contact manager application. You will also build a client to consume the API.
The REST architectural style has proven to be an effective way to leverage HTTP - although it is certainly not the only valid approach to HTTP. The contact manager will expose the RESTful for listing, adding and removing contacts, among others.
This lab requires a basic understanding of HTTP, REST, and assumes you have a basic working knowledge of HTML, JavaScript, and jQuery.

> **Note:** The ASP.NET Web site has an area dedicated to the ASP.NET Web API framework at [http://asp.net/web-api](http://asp.net/web-api). This site will continue to provide late-breaking information, samples, and news related to Web API, so check it frequently if you'd like to delve deeper into the art of creating custom Web API's available to virtually any device or development framework.

<a name="Objectives" />
### Objectives ###

In this hands-on lab, you will learn how to:

- Implement a RESTful Web API

- Call the API from an HTML client

<a name="Prerequisites" />
### Prerequisites ###

The following is required to complete this hands-on lab:

- [Microsoft Visual Studio Express 2012 for Web](http://www.microsoft.com/visualstudio/eng/products/visual-studio-express-for-web) or superior (read [Appendix B](#AppendixB) for instructions on how to install it).

- [ASP.NET MVC 4](http://www.asp.net/mvc/mvc4) (included in the Microsoft Visual Studio Express 2012 for Web installation)

<a name="CodeSnippets" />
### Installing Code Snippets ###

For convenience, much of the code you will be managing along this lab is available as Visual Studio code snippets. To install the code snippets run **.\Source\Setup\CodeSnippets.vsi** file.
 
If you are not familiar with the Visual Studio Code Snippets, and want to learn how to use them, you can refer to the appendix from this document "[Appendix: Using Code Snippets](#AppendixA)".

<a name="Exercises"/>
## Exercises ##

This hands-on lab includes the following exercise:

1. [Exercise 1: Create a Read-Only Web API ](#Exercise1)

1. [Exercise 2: Create a Read/Write Web API ](#Exercise2)

1. [Exercise 3: Consume the Web API from an HTML Client ](#Exercise3)

 
Estimated time to complete this lab: **60 minutes**.

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Every predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this lab describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in these procedures that you need to take into account. 

<a name="Exercise1" />
### Exercise 1: Create a Read-Only Web API ###

In this exercise, you will implement the read-only GET methods for the contact manager.

<a name="Ex1Task1" />
#### Task 1 - Creating the API Project ####

In this task, you will use the new ASP.NET web project templates to create a Web API web application.

1. Run **Visual Studio 2012 Express for Web**, to do this go to **Start** and type **VS Express for Web** then press **Enter**.

1. From the **File** menu, select **New Project**. Select the **Visual C# | Web** project type from the project type tree view, then select the **ASP.NET MVC 4 Web Application** project type. Set the project's **Name** to _ContactManager_ and the **Solution name** to _Begin_, then click **OK**.

 	![Creating a new MVC 4.0 Web Application Project](./images/Creating-a-new-MVC-4.0-Web-Application-Project.png?raw=true "Creating a new MVC 4.0 Web Application Project")
 
	_Creating a new MVC 4.0 Web Application Project_

1. In the ASP.NET MVC 4 project type dialog, select the **Web API** project type. Click **OK**.

 	![Specifying the Web API project type](./images/Specifying-the-Web-API-project-type.png?raw=true "Specifying the Web API project type")
 
 	_Specifying the Web API project type_

<a name="Ex1Task2" />
#### Task 2 - Creating the Contact Manager API Controllers ####

In this task, you will create the controller classes in which API methods will reside.

1. Delete the file named **ValuesController.cs** within **Controllers** folder from the project.

1. Right-click the **Controllers** folder in the project and select **Add | Controller** from the context menu.

 	![Adding a new controller to the project](./images/Adding-a-new-controller-to-the-project.png?raw=true "Adding a new controller to the project")
 
	_Adding a new controller to the project_

1. In the **Add Controller** dialog that appears, select **Empty API Controller** from the Template menu. Name the controller class **ContactController**. Then, click **Add.**

 	![Using the Add Controller dialog to create a new Web API controller](./images/Using-the-Add-Controller-dialog-to-create-a-new-Web-API-controller.png?raw=true "Using the Add Controller dialog to create a new Web API controller")
 
	_Using the Add Controller dialog to create a new Web API controller_

1. Add the following code to the **ContactController**.

	(Code Snippet - _Web API Lab - Ex01 - Get API Method_)
	<!-- mark:1-8 -->
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

1. Press the **F12** key to open the **Developer Tools** window. Click the **Network** tab, and then click the **Start Capturing** button to begin capturing network traffic into the window.

 	![Opening the network tab and initiating network capture](./images/Opening-the-network-tab-and-initiating-network-capture.png?raw=true "Opening the network tab and initiating network capture")
 
	_Opening the network tab and initiating network capture_

1. Append the URL in the browser's address bar with **/api/contact** and press enter. The transmission details will appear in the network capture window. Note that the response's MIME type is **application/json**. This demonstrates how the default output format is JSON.

 	![Viewing the output of the Web API request in the Network view](./images/Viewing-the-output-of-the-Web-API-request-in-the-Network-view.png?raw=true "Viewing the output of the Web API request in the Network view")
 
	_Viewing the output of the Web API request in the Network view_

	> **Note:** Internet Explorer 10's default behavior at this point will be to ask if the user would like to save or open the stream resulting from the Web API call. The output will be a text file containing the JSON result of the Web API URL call. Do not cancel the dialog in order to be able to watch the response's content through Developers Tool window. 

1. Click the **Go to detailed view** button to see more details about the response of this API call.

	![Switch to Detailed View](images/switch-to-details-view.png?raw=true "Switch to Details View")

	_Switch to Detailed View_

1. Click the **Response body** tab to view the actual JSON response text.

 	![Viewing the JSON output text in the network monitor](./images/Viewing-the-JSON-output-text-in-the-network-monitor.png?raw=true "Viewing the JSON output text in the network monitor")
 
 	_Viewing the JSON output text in the network monitor_

<a name="Ex1Task3" />
#### Task 3 - Creating the Contact Models and Augment the Contact Controller ####

In this task, you will create the controller classes in which API methods will reside.

1. Right-click the **Models** folder and select **Add | Class...** from the context menu.

 	![Adding a new model to the web application](./images/Adding-a-new-model-to-the-web-application.png?raw=true "Adding a new model to the web application")
 
	_Adding a new model to the web application_

1. In the **Add New Item** dialog, name the new file **Contact.cs** and click **Add.**

 	![Creating the new Contact class file](./images/Creating-the-new-Contact-class-file.png?raw=true "Creating the new Contact class file")
 
	_Creating the new Contact class file_

1. Add the following highlighted code to the **Contact** class.

	(Code Snippet - _Web API Lab - Ex01 - Get API Method_)
	
	<!-- mark: 3-4 -->
	````C#
	public class Contact
	{
	    public int Id { get; set; }
	    public string Name { get; set; }
	}
	````

1. In the **ContactController** class, select the word **string** in method definition of the **Get** method, and type the word _Contact_. Once the word is typed in, an indicator will appear at the beginning of the word **Contact**. Either hold down the **Ctrl** key and press the period (.) key or click the icon using your mouse to open up the assistance dialog in the code editor, to automatically fill in the **using** directive for the Models namespace.

	![Using Intellisense assistance for namespace declarations](images/Using-Intellisense-assistance-for-namespace-declarations.png?raw=true)

	_Using Intellisense assistance for namespace declarations_

1. Modify the code for the **Get** method so that it returns an array of Contact model instances.

	(Code Snippet - _Web API Lab - Ex01 - Returning a list of contacts_)

	<!-- mark:3-15 -->
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
	1. Once the browser opens, press **F12** to re-open the developer tools.
	1. Click the **Network** tab.
	1. Press the **Start Capturing** button.
	1. Add the URL suffix **/api/contact** to the URL in the address bar and press the **Enter** key.
	1. Press the **Go to detailed view** button.
	1. Select the **Response body** tab. You should see a JSON string representing the serialized form of an array of Contact instances.

 	![JSON serialized output of a complex Web API method call](./images/JSON-serialized-output-of-a-complex-Web-API-method-call.png?raw=true "JSON serialized output of a complex Web API method call")
 
 	_JSON serialized output of a complex Web API method call_

<a name="Ex1Task4" />
#### Task 4 - Extracting Functionality into a Service Layer ####

This task will demonstrate how to extract functionality into a Service layer to make it easy for developers to separate their service functionality from the controller layer, thereby allowing reusability of the services that actually do the work.

1. Create a new folder in the solution root and name it **Services**. To do this, right click **ContactManager** solution, select **Add** | **New Folder**, name it _Services_.

	![Creating Services folder](images/creating-services-folder.png?raw=true "Creating Services folder")

	_Creating Services folder_

1. Right-click the **Services** folder and select **Add | Class...** from the context menu.

	![Adding a new class to the Services folder](images/adding-a-new-class-to-the-services-folder.png?raw=true "Adding a new class to the Services folder")
 
	_Adding a new class to the Services folder_

1. When the **Add New Item** dialog appears, name the new class **ContactRepository** and click **Add**.

 	![Creating a class file to contain the code for the Contact Repository service layer](./images/Creating-a-class-file-to-contain-the-code-for-the-Contact-Repository-service-layer.png?raw=true "Creating a class file to contain the code for the Contact Repository service layer")
 
	_Creating a class file to contain the code for the Contact Repository service layer_

1. Add a using directive to the **ContactRepository.cs** file to include the models namespace.

	<!-- mark: 1 -->
	````C#
	using ContactManager.Models;
	````

1. Add the following highlighted code to the **ContactRepository.cs** file to implement GetAllContacts method.

	(Code Snippet - _Web API Lab - Ex01 - Contact Repository_)
	<!-- mark: 3-18 -->
	````C#
	public class ContactRepository
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


1. Open the **ContactController.cs** file if it is not already open.

1. Add the following using statement to the namespace declaration section of the file.

	<!-- mark: 1 -->
	````C#
	using ContactManager.Services;
	````

1. Add the following highlighted code to the **ContactController.cs** class to add a private field to represent the instance of the repository, so that the rest of the class members can make use of the service implementation.

	(Code Snippet - _Web API Lab - Ex01 - Contact Controller_)

	<!-- mark: 2-7 -->
	````C#
	public class ContactController : ApiController
	{
	    private ContactRepository _contactRepository;

        public ContactController()
        {
            this._contactRepository = new ContactRepository();
        } 
		...
	}
	````

1. Change the **Get** method so that it makes use of the contact repository service.

	(Code Snippet - _Web API Lab - Ex01 - Returning a list of contacts via the repository_)

	<!-- mark: 3 -->
	````C#
	public Contact[] Get()
	{
	    return _contactRepository.GetAllContacts();
	}
	````

1. Put a breakpoint on the **ContactController**'s **Get** method definition.

 	![Adding breakpoints to the contact controller](./images/Adding-breakpoints-to-the-contact-controller.png?raw=true "Adding breakpoints to the contact controller")
 
	_Adding breakpoints to the contact controller_

1. Press **F5** to run the application.

1. When the browser opens, press **F12** to open the developer tools.

1. Click the **Network** tab.

1. Click the **Start Capturing** button.

1. Append the URL in the address bar with the suffix **/api/contact** and press **Enter** to load the API controller.

1. Visual Studio 2012 should break once **Get** method begins execution.

 	![Breaking within the Get method](./images/Breaking-within-the-Get-method.png?raw=true "Breaking within the Get method")
 
	_Breaking within the Get method_

1. Press **F5** to continue.

1. Go back to Internet Explorer if it is not already in focus. Note the network capture window.

 	![Network view in Internet Explorer showing results of the Web API call](./images/Network-view-in-Internet-Explorer-showing-results-of-the-Web-API-call.png?raw=true "Network view in Internet Explorer showing results of the Web API call")
 
	_Network view in Internet Explorer showing results of the Web API call_

1. Click the **Go to detailed view** button.

1. Click the **Response body** tab. Note the JSON output of the API call, and how it represents the two contacts retrieved by the service layer.

 	![Viewing the JSON output from the Web API in the developer tools window](./images/Viewing-the-JSON-output-from-the-Web-API-in-the-developer-tools-window.png?raw=true "Viewing the JSON output from the Web API in the developer tools window")
 
 	_Viewing the JSON output from the Web API in the developer tools window_

<a name="Exercise2" />
### Exercise 2: Create a Read/Write Web API ###

In this exercise, you will implement POST and PUT methods for the contact manager to enable it with data-editing features.

<a name="Ex2Task1" />
#### Task 1 - Opening the Web API Project ####

In this task, you will prepare to enhance the Web API project created in Exercise 1 so that it can accept user input.

1. Run **Visual Studio 2012 Express for Web**, to do this go to **Start** and type **VS Express for Web** then press **Enter**.

1. Open the **Begin** solution located at **Source/Ex02-ReadWriteWebAPI/Begin/** folder. Otherwise, you might continue using the **End** solution obtained by completing the previous exercise.
	1. If you opened the provided **Begin** solution, you will need to download some missing NuGet packages before continue. To do this, click **Project** and select **Manage NuGet Packages**.

	1. In the **Manage NuGet Packages** page, click **Restore** in order to download missing packages.

	1. Finally, build the solution by clicking **Build** | **Build Solution**.

1. Open the **Services/ContactRepository.cs** file.

<a name="Ex2Task2" />
#### Task 2 - Adding Data-Persistence Features to the Contact Repository Implementation ####

In this task, you will augment the ContactRepository class of the Web API project created in Exercise 1 so that it can persist and accept user input and new Contact instances.

1. Add the following constant to the class to represent the name of the web server cache item key name later in this exercise.

	<!-- mark: 1 -->
	````C#
	const string cacheKey = "ContactStore";
	````

1. Add a constructor to the **ContactRepository** containing the following code.

	(Code Snippet - _Web API Lab - Ex02 - Contact Repository Constructor_)
	<!-- mark: 1-24 -->
	````C#
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

1. Modify the code for the **GetAllContacts** method as demonstrated below.

	(Code Snippet - _Web API Lab - Ex02 - Get All Contacts_)
	<!-- mark: 2-17 -->
	````C#
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

1. Implement a new method named **SaveContact** to the **ContactRepository** class to do the work of saving a contact. The **SaveContact** method should take a single **Contact** parameter and return a Boolean value indicating success or failure.

	(Code Snippet - _Web API Lab - Ex02 - Implementing the SaveContact Method_)
	<!-- mark: 1-25-->
	````C#
	public bool SaveContact(Contact contact)
	  {
			var ctx = HttpContext.Current;

			if (ctx != null)
			{
				 try
				 {
					  var currentData = ((Contact[])ctx.Cache[cacheKey]).ToList();
					  currentData.Add(contact);
					  ctx.Cache[cacheKey] = currentData.ToArray();

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

<a name="Exercise3" />
### Exercise 3: Consume the Web API from an HTML Client ###

In this exercise, you will create an HTML client to call the Web API. This client will facilitate data exchange with the Web API using JavaScript and will display the results in a web browser using HTML markup.

<a name="Ex3Task1" />
#### Task 1 - Modifying the Index View to Provide a GUI for Displaying Contacts ####

In this task, you will modify the default Index view of the web application to support the requirement of displaying the list of existing contacts in an HTML browser.

1. Open **Visual Studio 2012 Express for Web** if it is not already open.

1. Open the **Begin** solution located in the **Ex03/Begin** folder accompanying this lab.

1. Open the **Begin** solution located at **Source/Ex03-ConsumingWebAPI/Begin/** folder. Otherwise, you might continue using the **End** solution obtained by completing the previous exercise.
	1. If you opened the provided **Begin** solution, you will need to download some missing NuGet packages before continue. To do this, click **Project** and select **Manage NuGet Packages**.

	1. In the **Manage NuGet Packages** page, click **Restore** in order to download missing packages.

	1. Finally, build the solution by clicking **Build** | **Build Solution**.

1. Open the **Index.cshtml** file located at **Views/Home** folder.

1. Replace the HTML code within the div element with id **body** so that it looks like the following code. 

	<!-- mark: 2 -->
	````HTML
	<div id="body">
	    <ul id="contacts"></ul>
	</div>
	````

1. Add the following Javascript code at the bottom of the file to perform the HTTP request to the Web API.

	<!-- mark: 1-14 -->
	````HTML
	@section scripts{
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
	}
	````

1. Open the **ContactController.cs** file if it is not already open.

1. Place a breakpoint on the **Get** method of the **ContactController** class.

 	![Placing a breakpoint on the Get method of the API controller](./images/Placing-a-breakpoint-on-the-Get-method-of-the-API-controller.png?raw=true "Placing a breakpoint on the Get method of the API controller")
 
	_Placing a breakpoint on the Get method of the API controller_

1. Press **F5** to run the project. The browser will load the HTML document.

	> **Note:** Ensure that you are browsing to the root URL of your application.

1. Once the page loads and the JavaScript executes, the breakpoint will be hit and the code execution will pause in the controller.

	![Debugging into the Web API calls using VS Express for Web](images/debugging-into-the-web-api-calls-using-vs-exp.png?raw=true "Debugging into the Web API calls using VS Express for Web")
 
	_Debugging into the Web API call using Visual Studio 2012 Express for Web_

1. Remove the breakpoint and press **F5** or the debugging toolbar's **Continue** button to continue loading the view in the browser. Once the Web API call completes you should see the contacts returned from the Web API call displayed as list items in the browser.

 	![Results of the API call displayed in the browser as list items](./images/Results-of-the-API-call-displayed-in-the-browser-as-list-items.png?raw=true "Results of the API call displayed in the browser as list items")
 
 	_Results of the API call displayed in the browser as list items_

1. Stop debugging.

<a name="Ex3Task2" />
#### Task 2 - Modifying the Index View to Provide a GUI for Creating Contacts ####

In this task, you will continue to modify the Index view of the MVC application. A form will be added to the HTML page that will capture user input and send it to the Web API to create a new Contact, and a new Web API controller method will be created to collect date from the GUI.

1. Open the **ContactController.cs** file.

1. Add a new method to the controller class named **Post** as shown in the following code.

	(Code Snippet - _Web API Lab - Ex03 - Post Method_)
	<!-- mark: 1-8-->
	````C#
	public HttpResponseMessage Post(Contact contact)
	{
		 this._contactRepository.SaveContact(contact);

         var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            
         return response;
	}
	````
1. Open the **Index.cshtml** file in Visual Studio if it is not already open.

1. Add the HTML code below to the file just after the unordered list you added in the previous task.

	<!-- mark: 1-12 -->
	````HTML
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

1. Within the script element at the bottom of the document, add the following highlighted code to handle button-click events, which will post the data to the Web API using an HTTP POST call.

	<!-- mark: 3-16 -->
	````JavaScript
	<script type="text/javascript">
	...	
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
	</script>
	````

1. In **ContactController.cs**, place a breakpoint on the **Post** method.

1. Press **F5** to run the application in the browser.

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

<a name="Summary" />
## Summary ##

This lab has introduced you to the new ASP.NET Web API framework and to the implementation of RESTful Web API's using the framework. From here, you could create a new repository that facilitates data persistence using any number of mechanisms and wire that service up rather than the simple one provided as an example in this lab. Web API supports a number of additional features, such as enabling communication from non-HTML clients written in any language that supports HTTP and JSON or XML. The ability to host a Web API outside of a typical web application is also possible, as well as is the ability to create your own serialization formats.

The ASP.NET Web site has an area dedicated to the ASP.NET Web API framework at [http://asp.net/web-api](http://asp.net/web-api). This site will continue to provide late-breaking information, samples, and news related to Web API, so check it frequently if you'd like to delve deeper into the art of creating custom Web API's available to virtually any device or development framework.

<a name="AppendixA" />
## Appendix A: Using Code Snippets ##

With code snippets, you have all the code you need at your fingertips. The lab document will tell you exactly when you can use them, as shown in the following figure.

![Using Visual Studio code snippets to insert code into your project](./images/Using-Visual-Studio-code-snippets-to-insert-code-into-your-project.png?raw=true "Using Visual Studio code snippets to insert code into your project")

_Using Visual Studio code snippets to insert code into your project_

<a name="CodeSnippetUsingKeyBoard" />
### To add a code snippet using the keyboard (C# only) ###

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

<a name="CodeSnippetUsingMouse" />
### To add a code snippet using the mouse (C#, Visual Basic and XML) ###

1. Right-click where you want to insert the code snippet.

1. Select **Insert Snippet** followed by **My Code Snippets**.

1. Pick the relevant snippet from the list, by clicking on it.

	![Right-click where you want to insert the code snippet and select Insert Snippet](./images/Right-click-where-you-want-to-insert-the-code-snippet-and-select-Insert-Snippet.png?raw=true "Right-click where you want to insert the code snippet and select Insert Snippet")
 
	_Right-click where you want to insert the code snippet and select Insert Snippet_

	![Pick the relevant snippet from the list, by clicking on it](./images/Pick-the-relevant-snippet-from-the-list,-by-clicking-on-it.png?raw=true "Pick the relevant snippet from the list, by clicking on it")
 
	_Pick the relevant snippet from the list, by clicking on it_

<a name="AppendixB" />
## Appendix B: Installing Visual Studio Express 2012 for Web ##
You can install **Microsoft Visual Studio Express 2012 for Web** or another "Express" version using the **[Microsoft Web Platform Installer](http://www.microsoft.com/web/downloads/platform.aspx)**. The following instructions guide you through the steps required to install _Visual studio Express 2012 for Web_ using _Microsoft Web Platform Installer_.

1. Go to [http://go.microsoft.com/?linkid=9810169](http://go.microsoft.com/?linkid=9810169). Alternatively, if you already have installed Web Platform Installer, you can open it and search for the product "_Visual Studio Express 2012 for Web with Windows Azure SDK_".

1. Click on **Install Now**. If you do not have **Web Platform Installer** you will be redirected to download and install it first.

1. Once **Web Platform Installer** is open, click **Install** to start the setup.

	![Install Visual Studio Express](images/install-visual-studio-express.png?raw=true "Install Visual Studio Express")

 	_Install Visual Studio Express_

1. Read all the products' licenses and terms and click **I Accept** to continue.

	![Accepting the license terms](images/accepting-the-license-terms.png?raw=true)

	_Accepting the license terms_

1. Wait until the downloading and installation process completes.

	![Installation progress](images/installation-progress.png?raw=true)

	_Installation progress_

1. When the installation completes, click **Finish**.

	![Installation completed](images/installation-completed.png?raw=true)

	_Installation completed_

1. Click **Exit** to close Web Platform Installer.

1. To open Visual Studio Express for Web, go to the **Start** screen and start writing "**VS Express**", then click on the **VS Express for Web** tile.

	![VS Express for Web tile](images/vs-express-for-web-tile.png?raw=true)

	_VS Express for Web tile_



<a name="AppendixC" />
## Appendix C: Publishing an ASP.NET MVC 4 Application using Web Deploy ##

This appendix will show you how to create a new web site from the Windows Azure Management Portal and publish the application you obtained by following the lab, taking advantage of the Web Deploy publishing feature provided by Windows Azure.

<a name="ApxCTask1"></a>
#### Task 1 – Creating a New Web Site from the Windows Azure Portal ####

1. Go to the [Windows Azure Management Portal](https://manage.windowsazure.com/) and sign in using the Microsoft credentials associated with your subscription.

	![Log on to Windows Azure portal](images/login.png?raw=true "Log on to Windows Azure portal")

	_Log on to Windows Azure Management Portal_

1. Click **New** on the command bar.

	![Creating a new Web Site](images/new-website.png?raw=true "Creating a new Web Site")

	_Creating a new Web Site_

1. Click **Compute** | **Web Site**. Then select **Quick Create** option. Provide an available URL for the new web site and click **Create Web Site**.

	> **Note:** A Windows Azure Web Site is the host for a web application running in the cloud that you can control and manage. The Quick Create option allows you to deploy a completed web application to the Windows Azure Web Site from outside the portal. It does not include steps for setting up a database.

	![Creating a new Web Site using Quick Create](images/quick-create.png?raw=true "Creating a new Web Site using Quick Create")

	_Creating a new Web Site using Quick Create_

1. Wait until the new **Web Site** is created.

1. Once the Web Site is created click the link under the **URL** column. Check that the new Web Site is working.

	![Browsing to the new web site](images/navigate-website.png?raw=true "Browsing to the new web site")

	_Browsing to the new web site_

	![Web site running](images/website-working.png?raw=true "Web site running")

	_Web site running_

1. Go back to the portal and click the name of the web site under the **Name** column to display the management pages.

	![Opening the web site management pages](images/go-to-the-dashboard.png?raw=true "Opening the web site management pages")
	
	_Opening the Web Site management pages_

1. In the **Dashboard** page, under the **quick glance** section, click the **Download publish profile** link.

	> **Note:** The _publish profile_ contains all of the information required to publish a web application to a Windows Azure website for each enabled publication method. The publish profile contains the URLs, user credentials and database strings required to connect to and authenticate against each of the endpoints for which a publication method is enabled. **Microsoft WebMatrix 2**, **Microsoft Visual Studio Express for Web** and **Microsoft Visual Studio 2012** support reading publish profiles to automate configuration of these programs for publishing web applications to Windows Azure websites. 

	![Downloading the web site publish profile](images/download-publish-profile.png?raw=true "Downloading the web site publish profile")
	
	_Downloading the Web Site publish profile_

1. Download the publish profile file to a known location. Further in this exercise you will see how to use this file to publish a web application to a Windows Azure Web Sites from Visual Studio.

	![Saving the publish profile file](images/save-link.png?raw=true "Saving the publish profile")
	
	_Saving the publish profile file_

<a name="ApxCTask2"></a>
#### Task 2 – Configuring the Database Server ####

If your application makes use of SQL Server databases you will need to create a SQL Database server. If you want to deploy a simple application that does not use SQL Server you might skip this task.

1. You will need a SQL Database server for storing the application database. You can view the SQL Database servers from your subscription in the Windows Azure Management portal at **Sql Databases** | **Servers** | **Server's Dashboard**. If you do not have a server created, you can create one using the **Add** button on the command bar. Take note of the **server name and URL, administrator login name and password**, as you will use them in the next tasks. Do not create the database yet, as it will be created in a later stage.

	![SQL Database Server Dashboard](images/sql-database-server-dashboard.png?raw=true "SQL Database Server Dashboard")

	_SQL Database Server Dashboard_

1. In the next task you will test the database connection from Visual Studio, for that reason you need to include your local IP address in the server's list of **Allowed IP Addresses**. To do that, click **Configure**, select the IP address from **Current Client IP Address** and paste it on the **Start IP Address** and **End IP Address** text boxes and click the ![add-client-ip-address-ok-button](images/add-client-ip-address-ok-button.png?raw=true) button.

	![Adding Client IP Address](images/add-client-ip-address.png?raw=true)

	_Adding Client IP Address_

1. Once the **Client IP Address** is added to the allowed IP addresses list, click on **Save** to confirm the changes.

	![Confirm Changes](images/add-client-ip-address-confirm.png?raw=true)

	_Confirm Changes_

<a name="ApxCTask3"></a>
#### Task 3 – Publishing an ASP.NET MVC 4 Application using Web Deploy ####

1. Go back to the ASP.NET MVC 4 solution. In the **Solution Explorer**,  right-click the web site project and select **Publish**.

	![Publishing the Application](images/publishing-the-application.png?raw=true "Publishing the Application")

	_Publishing the web site_

1. Import the publish profile you saved in the first task.

	![Importing the publish profile](images/importing-the-publish-profile.png?raw=true "Importing the publish profile")

	_Importing publish profile_

1. Click **Validate Connection**. Once Validation is complete click **Next**.

	> **Note:** Validation is complete once you see a green checkmark appear next to the Validate Connection button.

	![Validating connection](images/validating-connection.png?raw=true "Validating connection")

	_Validating connection_

1. In the **Settings** page, under the **Databases** section, click the button next to your database connection's textbox (i.e. **DefaultConnection**).

	![Web deploy configuration](images/web-deploy-configuration.png?raw=true "Web deploy configuration")

	_Web deploy configuration_

1. Configure the database connection as follows:
	* In the **Server name** type your SQL Database server URL using the _tcp:_ prefix.
	* In **User name** type your server administrator login name.
	* In **Password** type your server administrator login password.
	* Type a new database name, for example: _MVC4SampleDB_.

	![Configuring destination connection string](images/configuring-destination-connection-string.png?raw=true "Configuring destination connection string")

	_Configuring destination connection string_

1. Then click **OK**. When prompted to create the database click **Yes**.

	![Creating the database](images/creating-the-database.png?raw=true "Creating the database string")

	_Creating the database_

1. The connection string you will use to connect to SQL Database in Windows Azure is shown within Default Connection textbox. Then click **Next**.

	![Connection string pointing to SQL Database](images/sql-database-connection-string.png?raw=true "Connection string pointing to SQL Database")

	_Connection string pointing to SQL Database_

1. In the **Preview** page, click **Publish**.

	![Publishing the web application](images/publishing-the-web-application.png?raw=true "Publishing the web application")

	_Publishing the web application_

1. Once the publishing process finishes, your default browser will open the published web site.

	![Application published to Windows Azure](images/application-published-to-windows-azure.png?raw=true "Application published to Windows Azure")

	_Application published to Windows Azure_
