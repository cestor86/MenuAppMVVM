using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using AppMenu_MVVM.Models;
using System.ComponentModel.DataAnnotations;

namespace AppMenu_MVVM.ViewModels
{

	partial class RegistroViewModel : ObservableObject
	{
		ObservableCollection<Registro> registros;
		Registro _registro;



		public RegistroViewModel()
		{
			_registro = new Registro();
			registros = new ObservableCollection<Registro>();
		}

		public RegistroViewModel(Registro r)
		{
			_registro = r;
        }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Nombre
		{
			get => _registro.nombre;
			set
			{
				if (this._registro.nombre != value)
				{
					_registro.nombre = value;
					OnPropertyChanged();
				}
			}
		}

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Direccion
		{
			get => _registro.direccion;
			set
			{
				if (_registro.direccion != value)
				{
					_registro.direccion = value;
					OnPropertyChanged();
				}
			}
		}

		public string Telefono
		{
			get => _registro.telefono;
			set
			{
				_registro.telefono = value;
				OnPropertyChanged();
			}
		}

		[RelayCommand]
		private async Task Add()
		{
			registros.Add(_registro);
			
			await Shell.Current.GoToAsync(nameof(Registro));
        }

        [RelayCommand]
		private async Task SelectCommand()=>
        await Shell.Current.GoToAsync(nameof(Registro));


		[RelayCommand]
		private void DeleteCommand()
		{
			registros.Remove(_registro);
		}
	}
}