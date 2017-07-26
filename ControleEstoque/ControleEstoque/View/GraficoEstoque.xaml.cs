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
	public partial class GraficoEstoque : ContentPage
	{

        public PlotModel BarModel { get; set; }
        MesEstoque entradaMes { get; set; }
        DadosEntradaSaidaService gerarGrafico = new DadosEntradaSaidaService();

        public GraficoEstoque ()
		{
			InitializeComponent();

            gerarGrafico.BuscarEntradaPorAno();

            MessagingCenter.Subscribe<MesEstoque>(this, "SucessoBuscarEntradaMes",
            (entrada) =>
            {
                this.entradaMes = entrada;
                gerarGrafico.BuscarSaidaPorAno();
            });

           MessagingCenter.Subscribe<MesEstoque>(this, "SucessoBuscarSaidaMes",
           (saida) =>
           {
               BarModel = CreateBarChart(false, "Entrada/Saída", this.entradaMes, saida);


               this.Content = new PlotView
               {
                   Model = BarModel,
                   VerticalOptions = LayoutOptions.Fill,
                   HorizontalOptions = LayoutOptions.Fill,
               };
           });
        }

        private PlotModel CreateBarChart(bool stacked, string title,MesEstoque entrada, MesEstoque saida)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Entrada", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s1.Items.Add(new BarItem { Value =  Convert.ToDouble(entrada.dezembro) });
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

            var s2 = new BarSeries { Title = "Saída", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.dezembro) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.novembro) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.outubro) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.setembro) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.agosto) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.julho) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.junho) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.maio) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.abril) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.marco) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.fevereiro) });
            s2.Items.Add(new BarItem { Value = Convert.ToDouble(saida.janeiro) });

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
            model.Series.Add(s2);
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