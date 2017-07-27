using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using ControleEstoque.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ControleEstoque.Models;
using System;

namespace ControleEstoque.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GraficoEntrada : ContentPage
	{
        public PlotModel BarModel { get; set; }
        MesEstoque entradaMes { get; set; }
        DadosEntradaSaidaService gerarGrafico = new DadosEntradaSaidaService();

        public GraficoEntrada (int idEmpresa)
		{
			InitializeComponent ();

            gerarGrafico.BuscarEntradaPorAno(idEmpresa);

            MessagingCenter.Subscribe<MesEstoque>(this, "SucessoBuscarEntradaMes",
            (entrada) =>
            {
                this.entradaMes = entrada;
                BarModel = CreateBarChart(false, "Entrada", this.entradaMes);


                this.Content = new PlotView
                {
                    Model = BarModel,
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill,
                };
            });
        }

        private PlotModel CreateBarChart(bool stacked, string title, MesEstoque entrada)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Entrada", IsStacked = stacked, StrokeColor = OxyColors.Green, StrokeThickness = 1 };
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.dezembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.novembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.outubro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.setembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.agosto) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.julho) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.junho) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.maio) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.abril) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.marco) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.fevereiro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(entrada.janeiro) });

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
            categoryAxis.Labels.Add("Janeiro");
            categoryAxis.Labels.Add("Fevereiro");
            categoryAxis.Labels.Add("Março");
            categoryAxis.Labels.Add("Abril");
            categoryAxis.Labels.Add("Maio");
            categoryAxis.Labels.Add("Junho");
            categoryAxis.Labels.Add("Julho");
            categoryAxis.Labels.Add("Agosto");
            categoryAxis.Labels.Add("Setembro");
            categoryAxis.Labels.Add("Outubro");
            categoryAxis.Labels.Add("Novembro");
            categoryAxis.Labels.Add("Dezembro");
            var valueAxis = new LinearAxis { Position = ValueAxisPosition(), MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Bottom;
            }

            return AxisPosition.Left;
        }

        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Left;
            }

            return AxisPosition.Bottom;
        }
    }
}