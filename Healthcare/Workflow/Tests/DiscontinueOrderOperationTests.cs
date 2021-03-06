#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

#if UNIT_TESTS

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ClearCanvas.Workflow;

namespace ClearCanvas.Healthcare.Workflow.Tests
{
    [TestFixture]
    public class DiscontinueOrderOperationTests
    {
        class ConcreteReportingProcedureStep : ReportingProcedureStep
        {

            public ConcreteReportingProcedureStep(Procedure procedure)
                : base(procedure, new ReportPart())
            {

            }

            public override string Name
            {
                get { return "Concrete Reporting Procedure Step"; }
            }

            protected override ProcedureStep CreateScheduledCopy()
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        [Test]
        public void Test_Execute()
        {
            Order order = new Order();
            OrderCancelInfo info = new OrderCancelInfo();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            Assert.AreEqual(OrderStatus.IP, order.Status);

            op.Execute(order, info);
        }

        [Test]
        [ExpectedException(typeof(WorkflowException))]
        public void Test_Execute_Scheduling()
        {
            Order order = new Order();
            OrderCancelInfo info = new OrderCancelInfo();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();

            Assert.AreEqual(OrderStatus.SC, order.Status);

            op.Execute(order, info);
        }

        [Test]
        [ExpectedException(typeof(WorkflowException))]
        public void Test_Execute_Complete()
        {
            Order order = new Order();
            OrderCancelInfo info = new OrderCancelInfo();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            procedure.Complete(DateTime.Now);
            order.UpdateStatus();
            Assert.AreEqual(OrderStatus.CM, order.Status);

            op.Execute(order, info);
        }

        [Test]
        [ExpectedException(typeof(WorkflowException))]
        public void Test_Execute_Discontinue()
        {
            Order order = new Order();
            OrderCancelInfo info = new OrderCancelInfo();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            order.Discontinue(new OrderCancelInfo());
            Assert.AreEqual(OrderStatus.DC, order.Status);

            op.Execute(order, info);
        }

        [Test]
        [ExpectedException(typeof(WorkflowException))]
        public void Test_Execute_Cancel()
        {
            Order order = new Order();
            OrderCancelInfo info = new OrderCancelInfo();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();

            order.Cancel(new OrderCancelInfo());
            order.UpdateStatus();
            Assert.AreEqual(OrderStatus.CA, order.Status);

            op.Execute(order, info);
        }

        [Test]
        public void Test_CanExecute_InProgress()
        {
            Order order = new Order();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            Assert.AreEqual(OrderStatus.IP, order.Status);

            Assert.IsTrue(op.CanExecute(order));
        }

        [Test]
        public void Test_CanExecute()
        {
            Order order = new Order();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();

            Assert.AreEqual(OrderStatus.SC, order.Status);
            Assert.IsFalse(op.CanExecute(order));
        }

        [Test]
        public void Test_CanExecute_Complete()
        {
            Order order = new Order();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            procedure.Complete(DateTime.Now);
            order.UpdateStatus();
            Assert.AreEqual(OrderStatus.CM, order.Status);

            Assert.IsFalse(op.CanExecute(order));
        }

        [Test]
        public void Test_CanExecute_Discontinue()
        {
            Order order = new Order();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();
            Procedure procedure = new Procedure();
            ModalityProcedureStep step = new ModalityProcedureStep(procedure, "New modality.", new Healthcare.Modality());
            order.AddProcedure(procedure);

            step.Start(new Staff());
            order.Discontinue(new OrderCancelInfo());
            Assert.AreEqual(OrderStatus.DC, order.Status);

            Assert.IsFalse(op.CanExecute(order));
        }

        [Test]
        public void Test_CanExecute_Cancel()
        {
            Order order = new Order();
            DiscontinueOrderOperation op = new DiscontinueOrderOperation();

            order.Cancel(new OrderCancelInfo());
            order.UpdateStatus();
            Assert.AreEqual(OrderStatus.CA, order.Status);

            Assert.IsFalse(op.CanExecute(order));
        }
    }
}

#endif
