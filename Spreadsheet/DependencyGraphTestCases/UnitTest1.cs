﻿/*
 * Ali Momeni - CS 3500 - Assignment 3 - February 1, 2015
 */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Formulas;
using System.Collections.Generic;

namespace Dependencies
{
    [TestClass]
    public class UnitTest1
    {
        // Testing simple functionalities of the Dependency Graph

        /// <summary>
        /// Testing without actual dependencies
        ///</summary>
        [TestMethod()]
        public void SimpleTest1()
        {
            DependencyGraph dg = new DependencyGraph();
            Assert.AreEqual(0, dg.Size);
        }

        /// <summary>
        /// Testing without actual dependencies
        ///</summary>
        [TestMethod()]
        public void SimpleTest2()
        {
            DependencyGraph dg = new DependencyGraph();
            Assert.AreEqual(false, dg.HasDependees("c"));
        }

        /// <summary>
        /// Testing without actual dependencies
        ///</summary>
        [TestMethod()]
        public void SimpleTest3()
        {
            DependencyGraph dg = new DependencyGraph();
            Assert.AreEqual(false, dg.HasDependents("m"));
        }

        /// <summary>
        /// Testing the enumerator method, with an empty dependency graph
        ///</summary>
        [TestMethod()]
        public void SimpleTest4()
        {
            DependencyGraph dg = new DependencyGraph();
            Assert.IsFalse(dg.GetDependees("a").GetEnumerator().MoveNext());
        }

        /// <summary>
        /// Testing the enumerator method, with an empty dependency graph
        ///</summary>
        [TestMethod()]
        public void SimpleTest5()
        {
            DependencyGraph dg = new DependencyGraph();
            Assert.IsFalse(dg.GetDependents("a").GetEnumerator().MoveNext());
        }

        /// <summary>
        /// Testing the remove method
        ///</summary>
        [TestMethod()]
        public void SimpleTest6()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.RemoveDependency("m", "b");
            Assert.AreEqual(0, dg.Size);
        }

        /// <summary>
        ///Replacing elements elements with an empty hashset
        ///</summary>
        [TestMethod()]
        public void SimpleTest7()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.ReplaceDependents("a", new HashSet<string>());
            Assert.AreEqual(0, dg.Size);
        }

        /// <summary>
        /// Pressing for HasDependees false return
        ///</summary>
        [TestMethod()]
        public void SimpleTest8()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("m", "b");
            dg.AddDependency("m", "c");
            Assert.IsFalse(dg.HasDependees("m"));
        }


        /// <summary>
        /// Adding 3 dependencies to a1
        ///</summary>
        [TestMethod()]
        public void AddTest1()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a1", "a2");
            dg.AddDependency("a1", "a3");
            dg.AddDependency("a1", "a4");
            Assert.AreEqual(3, dg.Size);
        }

        /// <summary>
        /// adding same dependency multiple times
        ///</summary>
        [TestMethod()]
        public void AddTest2()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a", "a1");
            dg.AddDependency("a", "a1");
            dg.AddDependency("a", "a1");
            dg.AddDependency("a", "a1");
            Assert.AreEqual(1, dg.Size);
        }

        /// <summary>
        /// adding and checking for correct dependee dependent relationships
        ///</summary>
        [TestMethod()]
        public void AddTest3()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a", "b");
            dg.AddDependency("a", "c");
            dg.AddDependency("a", "c");
            dg.AddDependency("d", "c");
            dg.AddDependency("g", "c");

            Assert.AreEqual(true, dg.HasDependents("a"));
            Assert.AreEqual(true, dg.HasDependees("b"));
            Assert.AreEqual(false, dg.HasDependents("b"));
            Assert.AreEqual(true, dg.HasDependees("c"));
            Assert.AreEqual(true, dg.HasDependents("d"));
            Assert.AreEqual(false, dg.HasDependents("c"));
            Assert.AreEqual(4, dg.Size);
        }

        /// <summary>
        /// adding and checking for correct dependee dependent relationships
        ///</summary>
        [TestMethod()]
        public void AddTest4()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a", "b");
            dg.AddDependency("a", "c");
            dg.AddDependency("a", "c");
            dg.AddDependency("d", "c");

            Assert.AreEqual(true, dg.HasDependents("a"));
            Assert.AreEqual(true, dg.HasDependees("b"));
            Assert.AreEqual(false, dg.HasDependents("b"));
            Assert.AreEqual(true, dg.HasDependees("c"));
            Assert.AreEqual(true, dg.HasDependents("d"));
            Assert.AreEqual(false, dg.HasDependents("c"));
            Assert.AreEqual(3, dg.Size);

            dg.RemoveDependency("a", "b");
            dg.RemoveDependency("a", "c");
            dg.RemoveDependency("d", "c");
            Assert.AreEqual(0, dg.Size);

        }


        /// <summary>
        /// testing getDepnendents
        ///</summary>
        [TestMethod()]
        public void AddTest5()
        {

            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a1", "a2");
            dg.AddDependency("a1", "a3");
            dg.AddDependency("a1", "a4");
            dg.AddDependency("a1", "a5");
            dg.AddDependency("a2", "a6");
            dg.AddDependency("a2", "a7");
            dg.AddDependency("a2", "a8");
            dg.AddDependency("a2", "a9");

            HashSet<String> dependents = new HashSet<string>(dg.GetDependents("a1"));

            Assert.IsTrue(dependents.Count == 4);
            Assert.IsTrue(dependents.Contains("a2"));
            Assert.IsTrue(dependents.Contains("a3"));
            Assert.IsTrue(dependents.Contains("a4"));
            Assert.IsTrue(dependents.Contains("a5"));


            HashSet<String> dependents2 = new HashSet<string>(dg.GetDependents("a2"));

            Assert.IsTrue(dependents2.Count == 4);
            Assert.IsTrue(dependents2.Contains("a6"));
            Assert.IsTrue(dependents2.Contains("a7"));
            Assert.IsTrue(dependents2.Contains("a8"));
            Assert.IsTrue(dependents2.Contains("a9"));

        }


        /// <summary>
        /// testing getDepnendees
        ///</summary>
        [TestMethod()]
        public void AddTest6()
        {

            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a2", "a1");
            dg.AddDependency("a3", "a1");
            dg.AddDependency("a4", "a1");
            dg.AddDependency("a5", "a1");
            dg.AddDependency("a6", "a1");


            HashSet<String> dependees = new HashSet<string>(dg.GetDependees("a1"));

            Assert.IsTrue(dependees.Count == 5);
            Assert.IsTrue(dependees.Contains("a2"));
            Assert.IsTrue(dependees.Contains("a3"));
            Assert.IsTrue(dependees.Contains("a4"));
            Assert.IsTrue(dependees.Contains("a5"));
            Assert.IsTrue(dependees.Contains("a6"));

        }

        /// <summary>
        /// testing replaceDependents method
        ///</summary>
        [TestMethod()]
        public void replaceDependents()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a1", "a2");
            dg.AddDependency("a1", "a2");
            dg.AddDependency("a1", "a3");
            dg.AddDependency("a1", "a4");
            dg.AddDependency("a1", "a5");

            dg.ReplaceDependents("a1", new HashSet<string>() { "a7", "a8", "a9", "a10", "a11", "a12" });
            HashSet<String> testDependentsHashTable = new HashSet<string>(dg.GetDependents("a1"));
            Assert.IsTrue(testDependentsHashTable.Contains("a8"));
            Assert.IsTrue(testDependentsHashTable.Contains("a9"));
            Assert.IsTrue(testDependentsHashTable.Contains("a10"));
            Assert.IsTrue(testDependentsHashTable.Contains("a11"));
            Assert.IsTrue(testDependentsHashTable.Contains("a12"));
            Assert.IsTrue(testDependentsHashTable.Contains("a7"));

        }

        /// <summary>
        /// testing replaceDependees method
        ///</summary>
        [TestMethod()]
        public void replaceDependees()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a2", "a1");
            dg.AddDependency("a3", "a1");
            dg.AddDependency("a4", "a1");
            dg.AddDependency("a5", "a1");
            dg.AddDependency("a6", "a1");

            dg.ReplaceDependees("a1", new HashSet<string>() { "a7", "a8", "a9", "a10", "a11", "a12" });

            HashSet<String> testDependentsHashTable = new HashSet<string>(dg.GetDependees("a1"));
            Assert.IsTrue(testDependentsHashTable.Contains("a8"));
            Assert.IsTrue(testDependentsHashTable.Contains("a9"));
            Assert.IsTrue(testDependentsHashTable.Contains("a10"));
            Assert.IsTrue(testDependentsHashTable.Contains("a11"));
            Assert.IsTrue(testDependentsHashTable.Contains("a12"));
            Assert.IsTrue(testDependentsHashTable.Contains("a7"));
        }


        /// <summary>
        /// testing removal more thouroughly
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            DependencyGraph dg = new DependencyGraph();
            dg.AddDependency("a2", "a1");
            dg.AddDependency("a3", "a1");
            dg.AddDependency("a4", "a1");
            dg.AddDependency("a5", "a1");
            dg.AddDependency("a6", "a1");

            dg.RemoveDependency("a2", "a1");
            dg.RemoveDependency("a3", "a1");
            dg.RemoveDependency("a4", "a1");
            dg.RemoveDependency("a5", "a1");
            dg.RemoveDependency("a6", "a1");

            Assert.AreEqual(0, dg.Size);

        }









        // Added DG Grading Test cases for debugging
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///This is a test class for DependencyGraphTest and is intended
        ///to contain all DependencyGraphTest Unit Tests
        ///</summary>
        [TestClass()]
        public class DependencyGraphTest
        {
            // ************************** TESTS ON EMPTY DGs ************************* //

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest1()
            {
                DependencyGraph t = new DependencyGraph();
                Assert.AreEqual(0, t.Size);
            }

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest2()
            {
                DependencyGraph t = new DependencyGraph();
                Assert.IsFalse(t.HasDependees("x"));
                Assert.IsFalse(t.HasDependents("x"));
            }

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest3()
            {
                DependencyGraph t = new DependencyGraph();
                Assert.IsFalse(t.GetDependees("x").GetEnumerator().MoveNext());
                Assert.IsFalse(t.GetDependents("x").GetEnumerator().MoveNext());
            }

            /// <summary>
            ///Removing from an empty DG shouldn't fail
            ///</summary>
            [TestMethod()]
            public void EmptyTest5()
            {
                DependencyGraph t = new DependencyGraph();
                t.RemoveDependency("x", "y");
            }

            /// <summary>
            ///Replace on an empty DG shouldn't fail
            ///</summary>
            [TestMethod()]
            public void EmptyTest6()
            {
                DependencyGraph t = new DependencyGraph();
                t.ReplaceDependents("x", new HashSet<string>());
                t.ReplaceDependees("y", new HashSet<string>());
            }


            // ************************ MORE TESTS ON EMPTY DGs *********************** //

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest7()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                Assert.AreEqual(1, t.Size);
                t.RemoveDependency("x", "y");
                Assert.AreEqual(0, t.Size);
            }

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest8()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                Assert.IsTrue(t.HasDependees("y"));
                Assert.IsTrue(t.HasDependents("x"));
                t.RemoveDependency("x", "y");
                Assert.IsFalse(t.HasDependees("y"));
                Assert.IsFalse(t.HasDependents("x"));
            }

            /// <summary>
            ///Empty graph should contain nothing
            ///</summary>
            [TestMethod()]
            public void EmptyTest9()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                IEnumerator<string> e1 = t.GetDependees("y").GetEnumerator();
                Assert.IsTrue(e1.MoveNext());
                Assert.AreEqual("x", e1.Current);
                IEnumerator<string> e2 = t.GetDependents("x").GetEnumerator();
                Assert.IsTrue(e2.MoveNext());
                Assert.AreEqual("y", e2.Current);
                t.RemoveDependency("x", "y");
                Assert.IsFalse(t.GetDependees("y").GetEnumerator().MoveNext());
                Assert.IsFalse(t.GetDependents("x").GetEnumerator().MoveNext());
            }

            /// <summary>
            ///Removing from an empty DG shouldn't fail
            ///</summary>
            [TestMethod()]
            public void EmptyTest11()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                Assert.AreEqual(t.Size, 1);
                t.RemoveDependency("x", "y");
                t.RemoveDependency("x", "y");
            }

            /// <summary>
            ///Replace on an empty DG shouldn't fail
            ///</summary>
            [TestMethod()]
            public void EmptyTest12()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                Assert.AreEqual(t.Size, 1);
                t.RemoveDependency("x", "y");
                t.ReplaceDependents("x", new HashSet<string>());
                t.ReplaceDependees("y", new HashSet<string>());
            }


            // ********************** Making Sure that Static Variables Weren't Used ****************** //
            ///<summary>
            ///It should be possibe to have more than one DG at a time.  This test is
            ///repeated because I want it to be worth more than 1 point.
            ///</summary>
            [TestMethod()]
            public void StaticTest1()
            {
                DependencyGraph t1 = new DependencyGraph();
                DependencyGraph t2 = new DependencyGraph();
                t1.AddDependency("x", "y");
                Assert.AreEqual(1, t1.Size);
                Assert.AreEqual(0, t2.Size);
            }

            [TestMethod()]
            public void StaticTest2()
            {
                StaticTest1();
            }

            [TestMethod()]
            public void StaticTest3()
            {
                StaticTest1();
            }

            [TestMethod()]
            public void StaticTest4()
            {
                StaticTest1();
            }

            [TestMethod()]
            public void StaticTest5()
            {
                StaticTest1();
            }

            /**************************** SIMPLE NON-EMPTY TESTS ****************************/

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest1()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                Assert.AreEqual(4, t.Size);
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest3()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                Assert.IsTrue(t.HasDependents("a"));
                Assert.IsFalse(t.HasDependees("a"));
                Assert.IsTrue(t.HasDependents("b"));
                Assert.IsTrue(t.HasDependees("b"));
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest4()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");

                IEnumerator<string> e = t.GetDependees("a").GetEnumerator();
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "a") && (s2 == "c")) || ((s1 == "c") && (s2 == "a")));

                e = t.GetDependees("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("a", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("d").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest5()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");

                IEnumerator<string> e = t.GetDependents("a").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "b") && (s2 == "c")) || ((s1 == "c") && (s2 == "b")));

                e = t.GetDependents("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("d", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("d").GetEnumerator();
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest6()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "b");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                t.AddDependency("c", "b");
                Assert.AreEqual(4, t.Size);
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest8()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "b");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                t.AddDependency("c", "b");
                Assert.IsTrue(t.HasDependents("a"));
                Assert.IsFalse(t.HasDependees("a"));
                Assert.IsTrue(t.HasDependents("b"));
                Assert.IsTrue(t.HasDependees("b"));
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest9()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "b");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                t.AddDependency("c", "b");

                IEnumerator<string> e = t.GetDependees("a").GetEnumerator();
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "a") && (s2 == "c")) || ((s1 == "c") && (s2 == "a")));

                e = t.GetDependees("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("a", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("d").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest10()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "b");
                t.AddDependency("c", "b");
                t.AddDependency("b", "d");
                t.AddDependency("c", "b");

                IEnumerator<string> e = t.GetDependents("a").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "b") && (s2 == "c")) || ((s1 == "c") && (s2 == "b")));

                e = t.GetDependents("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("d", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("d").GetEnumerator();
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest11()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "d");
                t.AddDependency("c", "b");
                t.RemoveDependency("a", "d");
                t.AddDependency("e", "b");
                t.AddDependency("b", "d");
                t.RemoveDependency("e", "b");
                t.RemoveDependency("x", "y");
                Assert.AreEqual(4, t.Size);
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest13()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "d");
                t.AddDependency("c", "b");
                t.RemoveDependency("a", "d");
                t.AddDependency("e", "b");
                t.AddDependency("b", "d");
                t.RemoveDependency("e", "b");
                t.RemoveDependency("x", "y");
                Assert.IsTrue(t.HasDependents("a"));
                Assert.IsFalse(t.HasDependees("a"));
                Assert.IsTrue(t.HasDependents("b"));
                Assert.IsTrue(t.HasDependees("b"));
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest14()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "d");
                t.AddDependency("c", "b");
                t.RemoveDependency("a", "d");
                t.AddDependency("e", "b");
                t.AddDependency("b", "d");
                t.RemoveDependency("e", "b");
                t.RemoveDependency("x", "y");

                IEnumerator<string> e = t.GetDependees("a").GetEnumerator();
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "a") && (s2 == "c")) || ((s1 == "c") && (s2 == "a")));

                e = t.GetDependees("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("a", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("d").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest15()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "y");
                t.AddDependency("a", "b");
                t.AddDependency("a", "c");
                t.AddDependency("a", "d");
                t.AddDependency("c", "b");
                t.RemoveDependency("a", "d");
                t.AddDependency("e", "b");
                t.AddDependency("b", "d");
                t.RemoveDependency("e", "b");
                t.RemoveDependency("x", "y");

                IEnumerator<string> e = t.GetDependents("a").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "b") && (s2 == "c")) || ((s1 == "c") && (s2 == "b")));

                e = t.GetDependents("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("d", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("d").GetEnumerator();
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest16()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "b");
                t.AddDependency("a", "z");
                t.ReplaceDependents("b", new HashSet<string>());
                t.AddDependency("y", "b");
                t.ReplaceDependents("a", new HashSet<string>() { "c" });
                t.AddDependency("w", "d");
                t.ReplaceDependees("b", new HashSet<string>() { "a", "c" });
                t.ReplaceDependees("d", new HashSet<string>() { "b" });
                Assert.AreEqual(4, t.Size);
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest18()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "b");
                t.AddDependency("a", "z");
                t.ReplaceDependents("b", new HashSet<string>());
                t.AddDependency("y", "b");
                t.ReplaceDependents("a", new HashSet<string>() { "c" });
                t.AddDependency("w", "d");
                t.ReplaceDependees("b", new HashSet<string>() { "a", "c" });
                t.ReplaceDependees("d", new HashSet<string>() { "b" });
                Assert.IsTrue(t.HasDependents("a"));
                Assert.IsFalse(t.HasDependees("a"));
                Assert.IsTrue(t.HasDependents("b"));
                Assert.IsTrue(t.HasDependees("b"));
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest19()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "b");
                t.AddDependency("a", "z");
                t.ReplaceDependents("b", new HashSet<string>());
                t.AddDependency("y", "b");
                t.ReplaceDependents("a", new HashSet<string>() { "c" });
                t.AddDependency("w", "d");
                t.ReplaceDependees("b", new HashSet<string>() { "a", "c" });
                t.ReplaceDependees("d", new HashSet<string>() { "b" });

                IEnumerator<string> e = t.GetDependees("a").GetEnumerator();
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "a") && (s2 == "c")) || ((s1 == "c") && (s2 == "a")));

                e = t.GetDependees("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("a", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependees("d").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());
            }

            /// <summary>
            ///Non-empty graph contains something
            ///</summary>
            [TestMethod()]
            public void NonEmptyTest20()
            {
                DependencyGraph t = new DependencyGraph();
                t.AddDependency("x", "b");
                t.AddDependency("a", "z");
                t.ReplaceDependents("b", new HashSet<string>());
                t.AddDependency("y", "b");
                t.ReplaceDependents("a", new HashSet<string>() { "c" });
                t.AddDependency("w", "d");
                t.ReplaceDependees("b", new HashSet<string>() { "a", "c" });
                t.ReplaceDependees("d", new HashSet<string>() { "b" });

                IEnumerator<string> e = t.GetDependents("a").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                String s1 = e.Current;
                Assert.IsTrue(e.MoveNext());
                String s2 = e.Current;
                Assert.IsFalse(e.MoveNext());
                Assert.IsTrue(((s1 == "b") && (s2 == "c")) || ((s1 == "c") && (s2 == "b")));

                e = t.GetDependents("b").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("d", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("c").GetEnumerator();
                Assert.IsTrue(e.MoveNext());
                Assert.AreEqual("b", e.Current);
                Assert.IsFalse(e.MoveNext());

                e = t.GetDependents("d").GetEnumerator();
                Assert.IsFalse(e.MoveNext());
            }


            // ************************** STRESS TESTS REPEATED MULTIPLE TIMES ******************************** //
            /// <summary>
            ///Using lots of data
            ///</summary>
            [TestMethod()]
            public void StressTest1()
            {
                // Dependency graph
                DependencyGraph t = new DependencyGraph();

                // A bunch of strings to use
                const int SIZE = 200;
                string[] letters = new string[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    letters[i] = ("" + (char)('a' + i));
                }

                // The correct answers
                HashSet<string>[] dents = new HashSet<string>[SIZE];
                HashSet<string>[] dees = new HashSet<string>[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    dents[i] = new HashSet<string>();
                    dees[i] = new HashSet<string>();
                }

                // Add a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 1; j < SIZE; j++)
                    {
                        t.AddDependency(letters[i], letters[j]);
                        dents[i].Add(letters[j]);
                        dees[j].Add(letters[i]);
                    }
                }

                // Remove a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 4; j < SIZE; j += 4)
                    {
                        t.RemoveDependency(letters[i], letters[j]);
                        dents[i].Remove(letters[j]);
                        dees[j].Remove(letters[i]);
                    }
                }

                // Add some back
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 1; j < SIZE; j += 2)
                    {
                        t.AddDependency(letters[i], letters[j]);
                        dents[i].Add(letters[j]);
                        dees[j].Add(letters[i]);
                    }
                }

                // Remove some more
                for (int i = 0; i < SIZE; i += 2)
                {
                    for (int j = i + 3; j < SIZE; j += 3)
                    {
                        t.RemoveDependency(letters[i], letters[j]);
                        dents[i].Remove(letters[j]);
                        dees[j].Remove(letters[i]);
                    }
                }

                // Make sure everything is right
                for (int i = 0; i < SIZE; i++)
                {
                    Assert.IsTrue(dents[i].SetEquals(new HashSet<string>(t.GetDependents(letters[i]))));
                    Assert.IsTrue(dees[i].SetEquals(new HashSet<string>(t.GetDependees(letters[i]))));
                }
            }

            [TestMethod()]
            public void StressTest2()
            {
                StressTest1();
            }
            [TestMethod()]
            public void StressTest3()
            {
                StressTest1();
            }
            [TestMethod()]
            public void StressTest4()
            {
                StressTest1();
            }
            [TestMethod()]
            public void StressTest5()
            {
                StressTest1();
            }


            // ********************************** ANOTHER STESS TEST, REPEATED ******************** //
            /// <summary>
            ///Using lots of data with replacement
            ///</summary>
            [TestMethod()]
            public void StressTest8()
            {
                // Dependency graph
                DependencyGraph t = new DependencyGraph();

                // A bunch of strings to use
                const int SIZE = 400;
                string[] letters = new string[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    letters[i] = ("" + (char)('a' + i));
                }

                // The correct answers
                HashSet<string>[] dents = new HashSet<string>[SIZE];
                HashSet<string>[] dees = new HashSet<string>[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    dents[i] = new HashSet<string>();
                    dees[i] = new HashSet<string>();
                }

                // Add a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 1; j < SIZE; j++)
                    {
                        t.AddDependency(letters[i], letters[j]);
                        dents[i].Add(letters[j]);
                        dees[j].Add(letters[i]);
                    }
                }

                // Remove a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 2; j < SIZE; j += 3)
                    {
                        t.RemoveDependency(letters[i], letters[j]);
                        dents[i].Remove(letters[j]);
                        dees[j].Remove(letters[i]);
                    }
                }

                // Replace a bunch of dependents
                for (int i = 0; i < SIZE; i += 2)
                {
                    HashSet<string> newDents = new HashSet<String>();
                    for (int j = 0; j < SIZE; j += 5)
                    {
                        newDents.Add(letters[j]);
                    }
                    t.ReplaceDependents(letters[i], newDents);

                    foreach (string s in dents[i])
                    {
                        dees[s[0] - 'a'].Remove(letters[i]);
                    }

                    foreach (string s in newDents)
                    {
                        dees[s[0] - 'a'].Add(letters[i]);
                    }

                    dents[i] = newDents;
                }

                // Make sure everything is right
                for (int i = 0; i < SIZE; i++)
                {
                    Assert.IsTrue(dents[i].SetEquals(new HashSet<string>(t.GetDependents(letters[i]))));
                    Assert.IsTrue(dees[i].SetEquals(new HashSet<string>(t.GetDependees(letters[i]))));
                }
            }

            [TestMethod()]
            public void StressTest9()
            {
                StressTest8();
            }
            [TestMethod()]
            public void StressTest10()
            {
                StressTest8();
            }
            [TestMethod()]
            public void StressTest11()
            {
                StressTest8();
            }
            [TestMethod()]
            public void StressTest12()
            {
                StressTest8();
            }


            // ********************************** A THIRD STESS TEST, REPEATED ******************** //
            /// <summary>
            ///Using lots of data with replacement
            ///</summary>
            [TestMethod()]
            public void StressTest15()
            {
                // Dependency graph
                DependencyGraph t = new DependencyGraph();

                // A bunch of strings to use
                const int SIZE = 800;
                string[] letters = new string[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    letters[i] = ("" + (char)('a' + i));
                }

                // The correct answers
                HashSet<string>[] dents = new HashSet<string>[SIZE];
                HashSet<string>[] dees = new HashSet<string>[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    dents[i] = new HashSet<string>();
                    dees[i] = new HashSet<string>();
                }

                // Add a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 1; j < SIZE; j++)
                    {
                        t.AddDependency(letters[i], letters[j]);
                        dents[i].Add(letters[j]);
                        dees[j].Add(letters[i]);
                    }
                }

                // Remove a bunch of dependencies
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = i + 2; j < SIZE; j += 3)
                    {
                        t.RemoveDependency(letters[i], letters[j]);
                        dents[i].Remove(letters[j]);
                        dees[j].Remove(letters[i]);
                    }
                }

                // Replace a bunch of dependees
                for (int i = 0; i < SIZE; i += 2)
                {
                    HashSet<string> newDees = new HashSet<String>();
                    for (int j = 0; j < SIZE; j += 9)
                    {
                        newDees.Add(letters[j]);
                    }
                    t.ReplaceDependees(letters[i], newDees);

                    foreach (string s in dees[i])
                    {
                        dents[s[0] - 'a'].Remove(letters[i]);
                    }

                    foreach (string s in newDees)
                    {
                        dents[s[0] - 'a'].Add(letters[i]);
                    }

                    dees[i] = newDees;
                }

                // Make sure everything is right
                for (int i = 0; i < SIZE; i++)
                {
                    Assert.IsTrue(dents[i].SetEquals(new HashSet<string>(t.GetDependents(letters[i]))));
                    Assert.IsTrue(dees[i].SetEquals(new HashSet<string>(t.GetDependees(letters[i]))));
                }
            }

            [TestMethod()]
            public void StressTest16()
            {
                StressTest15();
            }
            [TestMethod()]
            public void StressTest17()
            {
                StressTest15();
            }
            [TestMethod()]
            public void StressTest18()
            {
                StressTest15();
            }
            [TestMethod()]
            public void StressTest19()
            {
                StressTest15();
            }
        }
    }
}
