# CareerCloud2-NET-program  CareerCloud-Assigment
## Description:
In this assignment you will create class structures that represent database tables. These classes will be used to load data from the database into memory in later assignments. They will also be the foundation for the layered architecture we will build during the modules of our program.

### References:

- [x] Database Download 
    - (https://github.com/johnhinz/HumberDB.git)
    
- [x] SQL types and corresponding C# types 
    - (https://msdn.microsoft.com/en-us/library/cc716729(v=vs.110).aspx)

- [x]  Attribute classes that are used to define metadata for ASP.NET MVC, ASP.NET data controls and EntityFramework
    - (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.schema?view=netframework-4.7)
- and
    - (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.7)
- [x]  Working with Git 
    - (https://www.visualstudio.com/en-us/docs/git/tutorial/clone)
- [x] Working with Unit Tests
    - (https://www.visualstudio.com/en-us/docs/test/developer-testing/getting-started/getting-started-with-developer-testing)


## Folder view

<img width="964" alt="Folder" src="https://github.com/jaimehernan95/CareerCloud-Assigment1/blob/main/images/assigment1.png">

## File Structure

Within the download you'll find the following directories and files:
```
.

├── CareerCloud2
├── README.md
├── CareerCloud.sln
│
├── CareerCloud.ADODataAccessLayer
│   ├── SecurityLoginRepository.cs
│   ├── ApplicantWorkHistoryRepository.cs
│   └── ApplicantProfileRepository.cs
│   ├── ApplicantEducationRepository.cs
│   ├── ApplicantSkillRepository.cs
│   └── CompanyProfileRepository.cs
│   ├── CompanyProfileRepository.cs
│   ├── CompanyDescriptionRepository.cs
│   └── CompanyJobRepository.cs
│   ├── CompanyJobSkillRepository.cs
│   ├── SecurityLoginsLogRepository.cs
│   └── ApplicantJobApplicationRepository.cs
│   ├── CompanyJobDescriptionRepository.cs
│   ├── ApplicantResumeRepository.cs
│   └── CompanyJobEducationRepository.cs
│   ├── CompanyJobDescriptionRepository.cs
│   ├── ApplicantResumeRepository.cs
│   └── CompanyJobEducationRepository.cs
│   ├──SecurityLoginsRoleRepository.cs
│   ├──SecurityRoleRepository.cs
│   ├──SystemCountryCodeRepository.cs
│   ├──SystemLanguageCodeRepository.cs
│   ├──CareerCloud.ADODataAccessLayer.csproj
│
└── bin
│└──Debug
│└──obj
│└──project.assets.json
│└──CareerCloud.ADODataAccessLayer.csproj.nuget.dgspec.json
│└──project.nuget.cache
│└──CareerCloud.ADODataAccessLayer.csproj.nuget.g.props
│└──CareerCloud.ADODataAccessLayer.csproj.nuget.g.targets
│└──Debug
│
├── CareerCloud.DataAccessLayer
│   ├──IDataRepository.cs
│   ├──CareerCloud.DataAccessLayer.csproj
│   ├──bin
│   ├──Debug
│   ├──obj
│   ├──CareerCloud.DataAccessLayer.csproj.nuget.dgspec.json
│   ├──project.assets.json
│   ├──CareerCloud.DataAccessLayer.csproj.nuget.g.props
│   ├──project.nuget.cache
│   ├──CareerCloud.DataAccessLayer.csproj.nuget.g.targets
│   ├──Debug
│
├──CareerCloud.Pocos
│   ├──SecurityLoginPoco.cs
│   ├──ApplicantWorkHistoryPoco.cs
│   ├──ApplicantProfilePoco.cs
│   ├──ApplicantEducationPoco.cs
│   ├──ApplicantSkillPoco.cs
│   ├──CompanyLocationPoco.cs
│   ├──CompanyProfilePoco.cs
│   ├──CompanyJobPoco.cs
│   ├──CompanyDescriptionPoco.cs
│   ├──CompanyJobDescriptionPoco.cs
│   ├──CompanyJobSkillPoco.cs
│   ├──ApplicantJobApplicationPoco.cs
│   ├──SecurityLoginsLogPoco.cs
│   ├──CompanyJobEducationPoco.cs
│   ├──SecurityLoginsRolePoco.cs
│   ├──ApplicantResumePoco.cs
│   ├──SystemLanguageCodePoco.cs
│   ├──SecurityRolePoco.cs
│   ├──SystemCountryCodePoco.cs
│   ├──CareerCloud.Pocos.csproj
