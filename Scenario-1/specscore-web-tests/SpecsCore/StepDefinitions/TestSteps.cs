using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

[Binding]
public class TestSteps
{
    private readonly ScenarioContext context;

    public TestSteps(ScenarioContext scenarioContext)
    {
        context = scenarioContext;
    }

    TestPage _testPage = new TestPage();



    [When(@"test")]
    public void Whentest()
    { 
        _testPage.test();
    }


}