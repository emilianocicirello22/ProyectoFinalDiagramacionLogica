using System;

namespace TPfinal
{
    class FinalDiagramacion
    {
        static void Main(string[] args)
        {
            //Declaramos variables
            String codSan = " ", codPlan = " ", codAfil = " ";
            float valorPrest = 0, valXAfil = 0, valTfact = 0, mconsXAfil = 0;
            int edadAfil = 0;
            int cantAfil = 0, cantXSan = 0, cantMaxAfilSan = 0, cantMinAfilSan = 0;
            String codSanAux = " ", codPlanAux = " ", codAfilAux = " ";
            String presInput = " ";
            int contP1 = 0, contP2 = 0, contP3 = 0;
            bool afilMcons = true, mayorAfilSan = true;
            String sanShow = " ", afilShow = " ", sanShowAfilMax = " ", sanShowAfilMin = " ";

            //Iniciamos corte de control por Sanatorio
            while (!codSan.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            {
                //Ingresamos codigo de sanatorio
                Console.WriteLine("Ingrese codigo de sanatorio: San1 / San2 / San3 / San4 / San5");
                codSan = Console.ReadLine();
                //Hacemos una backup de codigo de sanatorio
                codSanAux = codSan;

                //Creamos corte de control para tipo de plan
                while (!codSan.Equals("N", StringComparison.InvariantCultureIgnoreCase) && !codPlan.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Ingresamos codigo de plan
                    Console.WriteLine("Ingrese codigo de plan PL1 / PL2 / PL3");
                    codPlan = Console.ReadLine();
                    //Hacemos una backup de codigo de plan
                    codPlanAux = codPlan;

                    //Creamos Corte de control para numero de afiliado
                    while (!codSan.Equals("N", StringComparison.InvariantCultureIgnoreCase)
                          && !codPlan.Equals("N", StringComparison.InvariantCultureIgnoreCase)
                          && !codAfil.Equals("N", StringComparison.InvariantCultureIgnoreCase)
                            )
                    {
                        //Ingresamos numero de afiliado
                        Console.WriteLine("Ingrese numero de afiliado 000001 a 999999");
                        codAfil = Console.ReadLine();
                        //Hacemos una backup del codigo de afiliado
                        codAfilAux = codAfil;

                        //Ingresamos edad del afiliado entre 0 y 115
                        do
                        {
                            Console.WriteLine("Ingrese edad entre 0 y 115 años");
                            edadAfil = int.Parse(Console.ReadLine());

                        } while (edadAfil < 0 || edadAfil > 115);
                        //fin ingreso de edad

                        //Contabilizamos un afiliado
                        cantAfil++;

                        //contabilizamos prestaciones
                        while (!presInput.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //ingresamos el valor de la prestacion usada
                            Console.WriteLine("Ingrese valor de prestacion");
                            valorPrest = float.Parse(Console.ReadLine());

                            //calculamos el calor de la prestacion
                            if (codPlan.Equals("PL1", StringComparison.InvariantCultureIgnoreCase) && valorPrest > 100)
                            {
                                //Si el plan es el 1 y se pasa del tope del plan se contabiliza el tope
                                valXAfil += 100;
                            }
                            else
                            {
                                if (codPlan.Equals("PL2", StringComparison.InvariantCultureIgnoreCase) && valorPrest > 200)
                                {
                                    //Si el plan es el 2 y se pasa del tope del plan se contabiliza el tope
                                    valXAfil += 200;
                                }
                                else
                                {
                                    if (codPlan.Equals("PL3", StringComparison.InvariantCultureIgnoreCase) && valorPrest > 300)
                                    {
                                        //Si el plan es el 3 y se pasa del tope del plan se contabiliza el tope
                                        valXAfil += 300;
                                    }
                                    else
                                    {
                                        //en caso de no pasarse del tope se contabiliza lo ingresado
                                        valXAfil += valorPrest;
                                    }
                                }
                            }

                            //Preguntamos si queremos seguir ingresando prestaciones
                            Console.WriteLine("Para continuar cargando prestaciones ingrese Y Para salir ingrese N");
                            presInput = Console.ReadLine();
                        }
                        //Fin de calculo de prestaciones

                        //Reiniciamos variable para cargar prestaciones
                        presInput = "";

                        //Preguntamos si queremos seguir cargando afiliados
                        Console.WriteLine("Para continuar cargando afiliados con mismo plan ingrese Y Para salir ingrese N");
                        codAfil = Console.ReadLine();

                        //Acumulamos la cantidad de afiliados para mostrar afiliados atendidos x sanatorios
                        cantXSan = cantXSan + cantAfil;

                        //Acumulamos el total de prestaciones para calcular facturacion x sanatorio
                        valTfact = valTfact + valXAfil;

                        //Mostramos el total de prestaciones consumidas x afiliado
                        Console.WriteLine($"El afiliado {codAfilAux} del sanatorio {codSanAux} consumio prestaciones por un valor total de: {valXAfil}");

                        //Contabilizamos el plan utilizado para calcular el plan con mayor atencion
                        if (codPlanAux.Equals("PL1", StringComparison.InvariantCultureIgnoreCase))
                        {
                            contP1++;
                        }
                        else
                        {
                            if (codPlanAux.Equals("PL2", StringComparison.InvariantCultureIgnoreCase))
                            {
                                contP2++;
                            }
                            else
                            {
                                if (codPlanAux.Equals("PL3", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    contP3++;
                                }
                            }
                        }
                        //Fin de contabilizacion de plan

                        //Reiniciamos variable contadora de afiliados
                        cantAfil = 0;

                        //En este contaremos al afiliado que genero mayor consumo por sanatorio
                        //Primero contaremos el primer valor para poder calcular 
                        if (afilMcons)
                        {
                            //Inicializamos la variable con el primer valor
                            mconsXAfil = valXAfil;

                            //Guardamos nro de afiliado y sanatorio
                            sanShow = codSanAux;
                            afilShow = codAfilAux;

                            //cambiamos la variable que nos permitio acumular el primer valor
                            afilMcons = false;

                        }
                        else
                        {
                            //en caso de que el valor acumulado sea menor al ingresado
                            if (mconsXAfil < valXAfil)
                            {
                                //reasignamos valores actuales
                                mconsXAfil = valXAfil;
                                sanShow = codSanAux;
                                afilShow = codAfilAux;
                            }
                        }
                        //Fin de calculo mayor consumo por sanatorio

                        //Reiniciamos variables donde acumulamos el valor consumido por afiliado
                        valXAfil = 0;

                    }
                    //Fin del primer corte de control
                    //Reiniciamos variable para cargar afiliado
                    codAfil = " ";
                    //Preguntamos si queremos cambiar valor de plan
                    Console.WriteLine("Ingrese Y para cambiar de plan ingrese N para salir");
                    codPlan = Console.ReadLine();
                }
                //Fin del segundo corte de control

                //Reiniciamos vaiable para cambiar plan
                codPlan = "";

                //Mostramos informacion
                Console.WriteLine($"El sanatorio {codSanAux} atendio: {cantXSan}");
                Console.WriteLine($"El sanatorio {codSanAux} facturo: {valTfact}");

                //Bloque para calcular Mayor y Menor cantidad de afiliados atendidos por sanatorio

                //Inicializamos los valores maximos y minimos para calcular 
                if (mayorAfilSan)
                {
                    //Inicializamos valor maximo y codigo de sanatorio
                    cantMaxAfilSan = cantXSan;
                    sanShowAfilMax = sanShow;

                    //Inicializamos valor minimo y codigo de sanatorio
                    cantMinAfilSan = cantXSan;
                    sanShowAfilMin = sanShow;

                    //Cambiamos valor de variable
                    mayorAfilSan = false;

                }
                else
                {
                    //Calculamos valor maximo
                    if (cantMaxAfilSan > cantXSan)
                    {
                        //Reasignamos valor maximo y codigo de sanatorio
                        cantMaxAfilSan = cantXSan;
                        sanShowAfilMax = sanShow;
                    }
                }

                //Calculamos valor minimo
                if (cantMinAfilSan < cantXSan)
                {
                    //Reasignamos valor minimo y codigo de sanatorio
                    cantMinAfilSan = cantXSan;
                    sanShowAfilMin = sanShow;
                }

                //Reiniciamos variables Valor total facturado y cantidad de afiliados por sanatorio
                cantXSan = 0;
                valTfact = 0;

                //Preguntamos si deseamos cambiar de sanatorio o salir 
                Console.WriteLine("Ingrese Y para cambiar de sanatorio, ingrese N para salir");
                codSan = Console.ReadLine();
            }
            //Fin de ultimo corte de control

            //Mostramos informacion
            Console.WriteLine($"El sanatorio {sanShowAfilMin} registro la menor cantidad de afiliados atendidos: {cantMinAfilSan}");
            Console.WriteLine($"El sanatorio {sanShowAfilMax} registro la mayor cantidad de afiliados atendidos: {cantMaxAfilSan}");
            Console.WriteLine($"El afiliado {afilShow} del sanatorio {sanShow} genero mayor consumo entre todos los afiliados por un total de: {mconsXAfil}");

            //Calculamos y mostramos plan con mas atenciones
            if (contP1 > contP2 && contP1 > contP3)
            {
                Console.WriteLine($"El plan PL1 registro {contP1} atenciones");
            }
            else
            {
                if (contP2 > contP3)
                {
                    Console.WriteLine($"El plan PL2 registro {contP2} atenciones");
                }
                else
                {
                    Console.WriteLine($"El plan PL3 registro {contP3} atenciones");
                }
            }
        }
    }