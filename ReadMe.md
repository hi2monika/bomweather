### How to run the project :
- Set the usage/usage project as startup project 
- Run the project
- Console application will ask to provide the path for CSV file (downloaded sample file--SampleCSV/*.csv)

### Project Approach :
BOMWeather : Library --.Net standard (be used as library)
Structure :
- DataSource : File Reader(Input)-- Provides the data.
- Services : Transform (BOMData -> ViewModel)
- BomClient : Workflow (Input/Transform/Output)
- Sample (console project is added for Demo)

Note : Client , contains the services (csv reader, json parser etc) and can be extended for the output as well to support multiple file type(same as IdataSource)

#### TODO :
- Functional (alternate approach)
  	For Yearly calculation : month Calculation can used as it been already doing the calculation(Performance improvement)
- Validation : 
  	Schema Verification can be done for csv.
- Exception Handling/Logging : 
  	Can be improved
- Unit Test:
  	Due to time Limitation I have only added the couple of unit test to demonstrate, every class can be unit tested.

### Alternate Approach:

In other approach, Project can be structured (clean architecture)
- Infrastructure :ClientDdata Source (csv)
  	Dependency: (Application Project)
- Application/Domain Project : Providers/Service/Interfaces/View Model/Model(Domain(csv) - becomes the part of application/Domain Project . 
  	Dependency: None
- Presentation: Console project 
  	Dependency : Application Project
	



