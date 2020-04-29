﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BackOff.Shared.Tests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class BackOffFeature : object, Xunit.IClassFixture<BackOffFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "OTP.feature"
#line hidden
        
        public BackOffFeature(BackOffFeature.FixtureData fixtureData, BackOff_Shared_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BackOff", "\tIn order to คำนวณบทลงโทษในการรอคอยได้\r\n\tAs a ระบบ\r\n\tI want ตรวจสอบความถูกต้องในก" +
                    "ารจัดการคำขอของผู้ใช้", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
#line 7
 testRunner.Given("ขณะนี้เวลา \'1/1/2020 00:00:00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="เบอร์โทรที่ยังไม่เคยมีบันทึกประวัติมาก่อนขอทำรายการ จะต้องขอดำเนินรายการได้ และจะ" +
            "ต้องรอ 1 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.TraitAttribute("FeatureTitle", "BackOff")]
        [Xunit.TraitAttribute("Description", "เบอร์โทรที่ยังไม่เคยมีบันทึกประวัติมาก่อนขอทำรายการ จะต้องขอดำเนินรายการได้ และจะ" +
            "ต้องรอ 1 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        public virtual void เบอรโทรทยงไมเคยมบนทกประวตมากอนขอทำรายการจะตองขอดำเนนรายการไดและจะตองรอ1นาทถงจะทำขอทำรายการใหมได()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("เบอร์โทรที่ยังไม่เคยมีบันทึกประวัติมาก่อนขอทำรายการ จะต้องขอดำเนินรายการได้ และจะ" +
                    "ต้องรอ 1 นาทีถึงจะทำขอทำรายการใหม่ได้", null, ((string[])(null)));
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Phone",
                            "AttemptCount"});
#line 10
 testRunner.Given("รายการเบอร์โทรในระบบเป็นดังนี้", ((string)(null)), table1, "Given ");
#line hidden
#line 12
 testRunner.When("เบอร์โทร \'0914185401\' ขอทำรายการ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ \'1\' และจะขอทำรายการได้ใหม่เมื่อเวลา \'1/1/2" +
                        "020 00:01:00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="เบอร์โทรที่ยังขอไม่เกิน 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 1 น" +
            "าทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.TraitAttribute("FeatureTitle", "BackOff")]
        [Xunit.TraitAttribute("Description", "เบอร์โทรที่ยังขอไม่เกิน 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 1 น" +
            "าทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.InlineDataAttribute("0914185400", "1", "1/1/2020 00:01:00", new string[0])]
        [Xunit.InlineDataAttribute("0914185401", "2", "1/1/2020 00:01:00", new string[0])]
        [Xunit.InlineDataAttribute("0914185402", "3", "1/1/2020 00:01:00", new string[0])]
        public virtual void เบอรโทรทยงขอไมเกน3ครงขอทำรายการจะตองขอดำเนนรายการไดและจะตองรอ1นาทถงจะทำขอทำรายการใหมได(string phone, string expectedAttemptCount, string expectedUnlockedTime, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("เบอร์โทรที่ยังขอไม่เกิน 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 1 น" +
                    "าทีถึงจะทำขอทำรายการใหม่ได้", null, exampleTags);
#line 15
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Phone",
                            "AttemptCount"});
                table2.AddRow(new string[] {
                            "0914185400",
                            "0"});
                table2.AddRow(new string[] {
                            "0914185401",
                            "1"});
                table2.AddRow(new string[] {
                            "0914185402",
                            "2"});
#line 16
 testRunner.Given("รายการเบอร์โทรในระบบเป็นดังนี้", ((string)(null)), table2, "Given ");
#line hidden
#line 21
 testRunner.When(string.Format("เบอร์โทร \'{0}\' ขอทำรายการ", phone), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 22
 testRunner.Then(string.Format("ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ \'{0}\' และจะขอทำรายการได้ใหม่เมื่อเวลา \'{1}" +
                            "\'", expectedAttemptCount, expectedUnlockedTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="เบอร์โทรที่ทำรายการมาแล้ว 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 3" +
            "0 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.TraitAttribute("FeatureTitle", "BackOff")]
        [Xunit.TraitAttribute("Description", "เบอร์โทรที่ทำรายการมาแล้ว 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 3" +
            "0 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        public virtual void เบอรโทรททำรายการมาแลว3ครงขอทำรายการจะตองขอดำเนนรายการไดและจะตองรอ30นาทถงจะทำขอทำรายการใหมได()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("เบอร์โทรที่ทำรายการมาแล้ว 3 ครั้งขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ 3" +
                    "0 นาทีถึงจะทำขอทำรายการใหม่ได้", null, ((string[])(null)));
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Phone",
                            "AttemptCount"});
                table3.AddRow(new string[] {
                            "0914185403",
                            "3"});
#line 31
 testRunner.Given("รายการเบอร์โทรในระบบเป็นดังนี้", ((string)(null)), table3, "Given ");
#line hidden
#line 34
 testRunner.When("เบอร์โทร \'0914185403\' ขอทำรายการ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
 testRunner.Then("ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ \'4\' และจะขอทำรายการได้ใหม่เมื่อเวลา \'1/1/2" +
                        "020 00:30:00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="เบอร์โทรถูกล๊อคและยังไม่ถึงเวลาที่กำหนดมาขอทำรายการ จะต้องดำเนินรายการไม่ได้ จนกว" +
            "่าจะถึงเวลาที่กำหนด")]
        [Xunit.TraitAttribute("FeatureTitle", "BackOff")]
        [Xunit.TraitAttribute("Description", "เบอร์โทรถูกล๊อคและยังไม่ถึงเวลาที่กำหนดมาขอทำรายการ จะต้องดำเนินรายการไม่ได้ จนกว" +
            "่าจะถึงเวลาที่กำหนด")]
        [Xunit.InlineDataAttribute("1/1/2020 00:28:00", new string[0])]
        [Xunit.InlineDataAttribute("1/1/2020 00:29:00", new string[0])]
        [Xunit.InlineDataAttribute("1/1/2020 00:29:59", new string[0])]
        public virtual void เบอรโทรถกลอคและยงไมถงเวลาทกำหนดมาขอทำรายการจะตองดำเนนรายการไมไดจนกวาจะถงเวลาทกำหนด(string currentTime, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("เบอร์โทรถูกล๊อคและยังไม่ถึงเวลาที่กำหนดมาขอทำรายการ จะต้องดำเนินรายการไม่ได้ จนกว" +
                    "่าจะถึงเวลาที่กำหนด", null, exampleTags);
#line 37
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Phone",
                            "AttemptCount",
                            "UnlockedTime"});
                table4.AddRow(new string[] {
                            "0914185404",
                            "4",
                            "1/1/2020 00:30:00"});
#line 38
 testRunner.Given("รายการเบอร์โทรในระบบเป็นดังนี้", ((string)(null)), table4, "Given ");
#line hidden
#line 41
 testRunner.And(string.Format("ขณะนี้เวลา \'{0}\'", currentTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.When("เบอร์โทร \'0914185404\' ขอทำรายการ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 43
 testRunner.Then("ขอดำเนินรายการไม่ได้ โดยเป็นการขอครั้งที่ \'4\' และจะขอทำรายการได้ใหม่เมื่อเวลา \'1/" +
                        "1/2020 00:30:00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="เบอร์โทรถูกล๊อคแต่เลยเวลาที่กำหนดมาขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ" +
            " 30 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.TraitAttribute("FeatureTitle", "BackOff")]
        [Xunit.TraitAttribute("Description", "เบอร์โทรถูกล๊อคแต่เลยเวลาที่กำหนดมาขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ" +
            " 30 นาทีถึงจะทำขอทำรายการใหม่ได้")]
        [Xunit.InlineDataAttribute("1/1/2020 00:30:00", "1/1/2020 01:00:00", new string[0])]
        [Xunit.InlineDataAttribute("1/1/2020 00:30:10", "1/1/2020 01:00:10", new string[0])]
        public virtual void เบอรโทรถกลอคแตเลยเวลาทกำหนดมาขอทำรายการจะตองขอดำเนนรายการไดและจะตองรอ30นาทถงจะทำขอทำรายการใหมได(string currentTime, string expectedUnlockedTime, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("เบอร์โทรถูกล๊อคแต่เลยเวลาที่กำหนดมาขอทำรายการ จะต้องขอดำเนินรายการได้ และจะต้องรอ" +
                    " 30 นาทีถึงจะทำขอทำรายการใหม่ได้", null, exampleTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Phone",
                            "AttemptCount",
                            "UnlockedTime"});
                table5.AddRow(new string[] {
                            "0914185404",
                            "4",
                            "1/1/2020 00:30:00"});
#line 52
 testRunner.Given("รายการเบอร์โทรในระบบเป็นดังนี้", ((string)(null)), table5, "Given ");
#line hidden
#line 55
 testRunner.And(string.Format("ขณะนี้เวลา \'{0}\'", currentTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.When("เบอร์โทร \'0914185404\' ขอทำรายการ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
 testRunner.Then(string.Format("ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ \'5\' และจะขอทำรายการได้ใหม่เมื่อเวลา \'{0}\'", expectedUnlockedTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                BackOffFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                BackOffFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
