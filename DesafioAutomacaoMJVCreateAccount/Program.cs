

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

CreateAccount();

static void CreateAccount()
{
    string firstName = "";
    string lastName = "";
    string email = "";
    string phone = "";
    string fax = "";
    string company = "";
    string address1 = "";
    string address2 = "";
    string city = "";
    string zone = "";
    string postCode = "";
    string country = "";
    string accountName = "";
    string password = "";
    string confirmPassword = "";
    bool sendTheNewsletter = false;
    bool iAgreeWithThePolicies = false;
    ///verifica mensagem de erro
    string errorMessage = "";

    /*
     Autora: Mônica Campos 
     Cel.:  11 96607-9416
     e-mail: Monica_RCampos@hotmail.com

    IMPORTANTE: 
        Foram utilizados os Nugets: Selenium.Support, Selenium.WebDriver e Seleniu.WebDriver.ChromeDriver
        
        Para enfrentar o desafio proposto, simplifiquei a solução ao máximo. 
        No dia-a-dia, eu optaria por organizar o código abaixo em classes e métodos separados, seguindo boas práticas de desenvolvimento.
        
     */

    ChromeOptions minhasOpcoesDoChrome = new ChromeOptions();
    ChromeDriver _driver = new ChromeDriver(minhasOpcoesDoChrome); 

    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

    _driver.Navigate().GoToUrl("https://automationteststore.com/index.php?rt=account/create");

    Thread.Sleep(1000);
    /*
     No contexto real, quando essa solução está operando em uma esteira DevOps, os dados abaixo poderiam vir de um banco de dados ou uma API.
    */
    firstName =  "Maria";
    lastName = "Silva";
    email = "maria1.silva@maria.com.br";
    phone = "12345-6789";
    fax = "43245566";
    company = "Empresa XPTO";
    address1 = "rua 1";
    address2 = "numero 2";
    city = "sao paulo";
    zone = "São paulo";
    postCode = "01411021";
    country = "Brasil";
    accountName = "minhaConta";
    password = "teste.100";
    confirmPassword = "teste.100";
    sendTheNewsletter = true;
    iAgreeWithThePolicies = true;

    ///LIMPAR CAMPOS
    ///Em um cenário de teste real, a limpeza de campos 
    ///seria normalmente encapsulada em um método isolado, 
    ///para prover a reutilização do código.
    try
    {
        _driver.FindElement(By.Id("AccountFrm_firstname")).Clear();
        _driver.FindElement(By.Id("AccountFrm_lastname")).Clear();
        _driver.FindElement(By.Id("AccountFrm_email")).Clear();
        _driver.FindElement(By.Id("AccountFrm_telephone")).Clear();
        _driver.FindElement(By.Id("AccountFrm_fax")).Clear();
        _driver.FindElement(By.Id("AccountFrm_company")).Clear();
        _driver.FindElement(By.Id("AccountFrm_address_1")).Clear();
        _driver.FindElement(By.Id("AccountFrm_address_2")).Clear();
        _driver.FindElement(By.Id("AccountFrm_city")).Clear();
        _driver.FindElement(By.Id("AccountFrm_zone_id")).Clear();
        _driver.FindElement(By.Id("AccountFrm_postcode")).Clear();
        _driver.FindElement(By.Id("AccountFrm_country_id")).Clear();
        _driver.FindElement(By.Id("AccountFrm_loginname")).Clear();
        _driver.FindElement(By.Id("AccountFrm_password")).Clear();
        _driver.FindElement(By.Id("AccountFrm_confirm")).Clear();
        _driver.FindElement(By.Id("AccountFrm_newsletter1")).Clear();
        _driver.FindElement(By.Id("AccountFrm_newsletter0")).Clear();
        _driver.FindElement(By.Id("AccountFrm_agree")).Clear();
    }
    catch
    {
        ///logar o erro e apontar falha no teste
    }


    ///PREENCHER CAMPOS DO FORMULÁRIO
    ///Em um cenário de teste real, esse bloco 
    ///seria normalmente encapsulado em um método isolado, 
    ///para prover a reutilização do código.
    _driver.FindElement(By.Id("AccountFrm_firstname")).SendKeys(firstName);
    _driver.FindElement(By.Id("AccountFrm_lastname")).SendKeys(lastName);
    _driver.FindElement(By.Id("AccountFrm_email")).SendKeys(email);
    _driver.FindElement(By.Id("AccountFrm_telephone")).SendKeys(phone);
    _driver.FindElement(By.Id("AccountFrm_fax")).SendKeys(fax);
    _driver.FindElement(By.Id("AccountFrm_company")).SendKeys(company);
    _driver.FindElement(By.Id("AccountFrm_address_1")).SendKeys(address1);
    _driver.FindElement(By.Id("AccountFrm_address_2")).SendKeys(address2);
    _driver.FindElement(By.Id("AccountFrm_city")).SendKeys(city);
    _driver.FindElement(By.Id("AccountFrm_postcode")).SendKeys(postCode);
    
    IWebElement ddlCountry = _driver.FindElement(By.Id("AccountFrm_country_id"));
    SelectElement selectCountry = new SelectElement(ddlCountry);
    selectCountry.SelectByValue(GetCountryCode(country));

    IWebElement ddlZone = _driver.FindElement(By.Id("AccountFrm_zone_id"));
    SelectElement selectZone = new SelectElement(ddlZone);
    selectZone.SelectByValue(GetZoneCode(zone));

    _driver.FindElement(By.Id("AccountFrm_loginname")).SendKeys(accountName);
    _driver.FindElement(By.Id("AccountFrm_password")).SendKeys(password);
    _driver.FindElement(By.Id("AccountFrm_confirm")).SendKeys(confirmPassword);
    
    if(sendTheNewsletter == true)
        _driver.FindElement(By.Id("AccountFrm_newsletter1")).Click();
    else
        _driver.FindElement(By.Id("AccountFrm_newsletter0")).Click();

    if(iAgreeWithThePolicies)
    {
        if(!((IWebElement)_driver.FindElement(By.Id("AccountFrm_agree"))).Selected)
            _driver.FindElement(By.Id("AccountFrm_agree")).Click();
    }
    
    //clica no botao continue
    _driver.FindElement(By.ClassName("btn-orange")).Click();

    try
    {
        errorMessage = _driver.FindElement(By.ClassName("alert")).Text;
    }
    catch { }
    if(!string.IsNullOrEmpty(errorMessage))
    {
        ///grava no resultado do teste sucesso
    }
    else
    {
        ///grava no resultado do teste erro e também a mensagem coletada
    }
}

static string GetZoneCode(string zoneDesc)
{
    zoneDesc = zoneDesc.ToLower();
    if (zoneDesc == "acre") return "440";
    if (zoneDesc == "alagoas") return "441";
    if (zoneDesc == "amapa") return "442";
    if (zoneDesc == "amazonas") return "443";
    if (zoneDesc == "bahia") return "444";
    if (zoneDesc == "ceara") return "445";
    if (zoneDesc == "distrito federal") return "446";
    if (zoneDesc == "espirito santo") return "447";
    if (zoneDesc == "goias") return "448";
    if (zoneDesc == "maranhao") return "449";
    if (zoneDesc == "mato grosso") return "450";
    if (zoneDesc == "mato grosso do sul") return "451";
    if (zoneDesc == "minas gerais") return "452";
    if (zoneDesc == "pará") return "453";
    if (zoneDesc == "paraíba") return "454";
    if (zoneDesc == "parana") return "455";
    if (zoneDesc == "pernambuco") return "456";
    if (zoneDesc == "piauí") return "457";
    if (zoneDesc == "rio de janeiro") return "458";
    if (zoneDesc == "rio grande do norte") return "459";
    if (zoneDesc == "rio grande do sul") return "460";
    if (zoneDesc == "rondonia") return "461";
    if (zoneDesc == "roraima") return "462";
    if (zoneDesc == "santa catarina") return "463";
    if (zoneDesc == "são paulo") return "464";
    if (zoneDesc == "sergipe") return "465";
    if (zoneDesc == "tocantins") return "466";
    return "FALSE";
}

static string GetCountryCode(string countryDesc)
{
    countryDesc = countryDesc.ToLower();
    if (countryDesc == "brasil" || countryDesc == "brazil") return "30";
    ///TODO: Implantar a mesma regra para os outros itens do dropdown
    return "FALSE";
}