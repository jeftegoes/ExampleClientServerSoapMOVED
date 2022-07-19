# Example client/server soap <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [1. What is this project](#1-what-is-this-project)
- [2. How is it organized](#2-how-is-it-organized)
  - [2.1. First way, importing the webservice wsdl by visual studio and generating the methods automatically.](#21-first-way-importing-the-webservice-wsdl-by-visual-studio-and-generating-the-methods-automatically)
  - [2.2. Second way, consuming manually using **WebResponse**.](#22-second-way-consuming-manually-using-webresponse)

### 1. What is this project

- This is a project that shows how to consume a soap webservice in two ways.
  - First way, importing the webservice wsdl by visual studio and generating the methods automatically.
  - Second way, consuming manually using WebResponse.

### 2. How is it organized

- SoapServer (.NET Framework 4.7.2 / SOAP Server)
- SoapClientCustomCall (.NET 6.0 / REST Client)
- SoapClientServiceReference (.NET 6.0 / REST Client)

#### 2.1. First way, importing the webservice wsdl by visual studio and generating the methods automatically.

1. Steps to import WSDL:
   ![SoapClientServiceReference](/Images/Step1.png)
2. Choose WCF Web Service
   ![SoapClientServiceReference](/Images/Step2.png)
3. Select endpoint and methods
   ![SoapClientServiceReference](/Images/Step3.png)
4. Create reference file
   ![SoapClientServiceReference](/Images/Step4.png)
5. Choose visibility classes
   ![SoapClientServiceReference](/Images/Step5.png)
6. Result
   ![SoapClientServiceReference](/Images/Result.png)

[SoapClientServiceReference](/src/SoapClientServiceReference/)

#### 2.2. Second way, consuming manually using **WebResponse**.

[SoapClientCustomCall](/src/SoapClientCustomCall/)
