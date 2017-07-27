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
	public partial class GraficoSaida : ContentPage
	{
        public PlotModel BarModel { get; set; }
        MesEstoque saidaMes { get; set; }
        DadosEntradaSaidaService gerarGrafico = new DadosEntradaSaidaService();


        public GraficoSaida (int idEmpresa)
		{
			InitializeComponent ();

            gerarGrafico.BuscarSaidaPorAno(idEmpresa);

            MessagingCenter.Subscribe<MesEstoque>(this, "SucessoBuscarSaidaMes",
            (saida) =>
            {
                this.saidaMes = saida;
                BarModel = CreateBarChart(false, "Saída", this.saidaMes);


                this.Content = new PlotView
                {
                    Model = BarModel,
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill,
                };
            });
        }

        private PlotModel CreateBarChart(bool stacked, string title, MesEstoque saida)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "saida", IsStacked = stacked, StrokeColor = OxyColors.Red, StrokeThickness = 1, FillColor = OxyColors.Red};
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.dezembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.novembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.outubro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.setembro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.agosto) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.julho) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.junho) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.maio) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.abril) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.marco) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.fevereiro) });
            s1.Items.Add(new BarItem { Value = Convert.ToDouble(saida.janeiro) });

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