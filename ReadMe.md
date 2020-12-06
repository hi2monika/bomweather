### How to run the project 
- Set the Usage as startup project 
- Console application will ask to provide the path for CSV file (Under the folder SampleCSV)

### Project Approch :
BOMWeather : Librabry --.Net standard (be used as library/compatible)
Structure :
- DataSource : File Reader(Input)
- Services : Trasnformation (Data)
- BomClient : Workflow (Input/Transform/Output)
- Sample (console project is added for Demo)
Note : Client , contains the services (csv reader, json parser etc) and can be extended for the output as well to support multiple file type(same as IdataSource)

#### TODO :
- Functional (alternate approach)
  For Yearly calculation : month Calculation can used as it been already doing the calculation
- Validation : 
  Schema Varrification can be done for csv.
- Exception Handling/Logging : 
  can be imporved
- Unit Test:
  Due to time Limitation I have only added the couple of unit test to demonstrate, every class can be unit tested.

### Alternate Approch :

In other approach, it could have been (clean architecture)
- Infrastructure :Client/dataSource (csv)
  Dependency : (Application Project)
- Application/Domain Project : Providers/Service/Interfaces/View Model/Model(Domain(csv) - becomes the part of application/Domain Project . 
  Dependency : None
- Presentation : Console project 
  Dependency : Application Project
	



