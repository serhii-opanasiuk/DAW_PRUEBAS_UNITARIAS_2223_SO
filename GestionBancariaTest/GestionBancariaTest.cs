using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void ValidarReintegroCantidadValida()
        {
            // preparación de los casos de prueba
            double saldoInicial = 1000;
            // cantidad válida (caso 3)
            double reintegroCantidadValida = 250;
            double saldoEsperadoValido = 750;
            // la variable para guardar el saldo corriente entre de las pruebas
            double saldoCorriente;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegroCantidadValida);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoEsperadoValido, saldoCorriente, 0.001,
            "Cantidad válida. Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNegativa()
        {
            // preparación de los casos de prueba
            double saldoInicial = 1000;
            // cantidad negativa (caso 1)
            double reintegroCantidadNegativa = -10;
            // la variable para guardar el saldo corriente entre de las pruebas
            double saldoCorriente;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            saldoCorriente = miApp.ObtenerSaldo();
            miApp.RealizarReintegro(reintegroCantidadNegativa);
            Assert.AreEqual(saldoCorriente, miApp.ObtenerSaldo(), 0.001,
           "Cantidad negativa. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadSuperaSaldo()
        {
            // preparación de los casos de prueba
            double saldoInicial = 1000;
            // cantidad que supera el saldo (caso 2)
            double reintegroCantidadSuperaSaldo = 1005;
            // la variable para guardar el saldo corriente entre de las pruebas
            double saldoCorriente;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegroCantidadSuperaSaldo);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoInicial, saldoCorriente, 0.001,
           "Cantidad que supera el saldo. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        [TestMethod]
        public void ValidarIngresoCantidadValida()
        {
            // preparación de los casos de prueba
            double saldoInicial = 500;
            // cantidad válida (caso 2)
            double ingresoCantidadValida = 80.07;
            double resultadoCantidadValida = 580.07;
            GestionBancariaApp miApp;
            double saldoCorriente;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            miApp.RealizarIngreso(ingresoCantidadValida);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(resultadoCantidadValida, saldoCorriente, 0.001,
            "Cantidad válida. Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNegativa()
        {
            // preparación de los casos de prueba
            double saldoInicial = 500;
            // cantidad negativa (caso 1)
            double ingresoCantidadNegativa = -3;
            GestionBancariaApp miApp;
            double saldoCorriente;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            miApp.RealizarIngreso(ingresoCantidadNegativa);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoInicial, saldoCorriente, 0.001,
            "Cantidad negativa. Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNegativaExcepcion()
        {
            // preparación de los casos de prueba
            double saldoInicial = 500;
            // cantidad negativa
            double ingresoCantidadNegativa = -3;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            miApp.RealizarIngreso(ingresoCantidadNegativa);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNegativaExcepcion()
        {
            // preparación de los casos de prueba
            double saldoInicial = 1000;
            // cantidad negativa
            double reintegroCantidadNegativa = -75.8;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            miApp.RealizarReintegro(reintegroCantidadNegativa);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegtoCantidadSuperaSaldoExcepcion()
        {
            // preparación de los casos de prueba
            double saldoInicial = 1500;
            // cantidad que supera el saldo
            double reintegroCantidadSuperaSaldo = 1502;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            miApp.RealizarReintegro(reintegroCantidadSuperaSaldo);
        }
        [TestMethod]
        public void ValidarReintegroCantidadNegativaReescrito()
        {
            // preparación de prueba
            double saldoInicial = 1500;
            // cantidad negativa
            double reintegroCantidadNegativa = -30;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegroCantidadNegativa);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        [TestMethod]
        public void ValidarReintegroCantidadSuperaSaldoReescrito()
        {
            // preparación de prueba
            double saldoInicial = 1500;
            // cantidad que supera el saldo
            double reintegroCantidadSuperaSaldo = 1530;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegroCantidadSuperaSaldo);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        [TestMethod]
        public void ValidarIngresoCantidadNegativaReescrito()
        {
            // preparación de prueba
            double saldoInicial = 1500;
            // cantidad negativa
            double ingresoCantidadNegativa = -30;
            GestionBancariaApp miApp;
            // Método a probar
            miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarIngreso(ingresoCantidadNegativa);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        //Métodos parametrizados
        //- Reintegro: número negativo o cero
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1000, -2, 1000)]
        [DataRow(25.8, -3.75, 25.8)]
        [DataRow(52, -1550, 52)]
        [DataRow(36.7, 0, 36.7)]
        public void ValidarReintegroParamNumeroNegativo(double saldoInicial, double reintegro,
            double saldoEsperado)
        {
            double saldoCorriente;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegro);
            saldoCorriente = miApp.ObtenerSaldo();          
            Assert.AreEqual(saldoEsperado, saldoCorriente, 0.001,
           "Cantidad negativa. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        //- Reintegro: número que supera el saldo
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1000, 1100, 1000)]
        [DataRow(25.8, 500, 25.8)]
        [DataRow(52, 52.1, 52)]
        [DataRow(36.7, 10500, 36.7)]
        public void ValidarReintegroParamSuperaSaldo(double saldoInicial, double reintegro,
            double saldoEsperado)
        {
            double saldoCorriente;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegro);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoCorriente, 0.001,
           "Cantidad supera el saldo. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        //- Reintegro: datos válidos
        [TestMethod]
        [DataRow(1000, 250, 750)]
        [DataRow(25.8, 3.17, 22.63)]
        [DataRow(52, 0.9, 51.1)]
        [DataRow(5.7, 5.7, 0)]
        public void ValidarReintegroParamValido(double saldoInicial, double reintegro,
            double saldoEsperado)
        {
            double saldoCorriente;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegro);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoCorriente, 0.001,
           "Error de los calculos. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        //- Ingreso: número negativo o cero
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(0, -3, 0)]
        [DataRow(25.8, -3.75, 25.8)]
        [DataRow(52, -1550, 52)]
        [DataRow(36.7, 0, 36.7)]
        public void ValidarIngresoParamNumeroNegativo(double saldoInicial, double ingreso,
            double saldoEsperado)
        {
            double saldoCorriente;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarIngreso(ingreso);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoCorriente, 0.001,
           "Cantidad negativa. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
        //- Ingreso: número válido
        [TestMethod]
        [DataRow(0, 52.5, 52.5)]
        [DataRow(25.8, 4.2, 30)]
        [DataRow(52, 17, 69)]
        [DataRow(36.7, 0.2, 36.9)]
        public void ValidarIngresoParamNumeroValido(double saldoInicial, double ingreso,
            double saldoEsperado)
        {
            double saldoCorriente;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarIngreso(ingreso);
            saldoCorriente = miApp.ObtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoCorriente, 0.001,
           "Error de los calculos. Se produjo un error al realizar el reintegro, saldo" +
           "incorrecto.");
        }
    }

}
