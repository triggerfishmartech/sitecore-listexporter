# sitecore-campaignlistexporter
Allows you to export the last known campaign ID of a contact in a list.

![Trigerfish Logo](https://avatars.githubusercontent.com/u/78132139?v=4)

## Compatibility
- Tested in Sitecore 10

## Prerequisites
- Working sc 10 instance
- xConnect service
- Custom Facets for sc Contacts

##Usage
### Note
The source code provides an example code on how to export the last known campaign ID of a contact in ListManager export.
Copy the Feature/code to your working sitecore repo if you are following Helix structure (please refer to the File structure below on details)
you need a proper working Sitecore 10 instance along with xConnect in order to test this E2E which is beyond the scope of this repo.

### File Structure
``` bash

Feature/
└── code/
    └── ContactDataReaders
        ├── CampaignContactDataReader.cs  //class implementing IContactDataReader
    └── xConnectModels
        ├── ContactCustomFieldsFacet.cs   //custom Facet class for example
    └── App_config
        ├── Feature.ListManager.config    // Patch for OOTB App_Config/Sitecore/ListManagement/Sitecore.ListManagement.config
```

### sitecore-campaignlistexporter
- Sitecore ListManagement API provides a way to export the custom fields to the List Manager export contacts to CSV feature.
- The code here makes use of the Sitecore ListManagement API in order to export the custom fields to the CSV using List Manager export contacts to CSV feature.
- The patch file consists of a class implementeing IContactDataReader which grabs the campaign Id from the contact 
& a field name which is column name on the export CSV.

### CSV example
[xls.png](https://postimg.cc/MMYPtcR2)

## Dependenent packages sc 10.0.0
- Sitecore.Kernel
- Sitecore.xConnect
- Sitecore.XConnect.Client
- Sitecore.XConnect.Client.Configuration
- Sitecore.EmailCampaign.Model
- Sitecore.ListManagement.XConnect
- Sitecore.ListManagement.XConnect.Web

##Good reference here on Listmanager fields export
![Link](https://sitecorify.com/list-manager-export-contacts-with-custom-facets/)

