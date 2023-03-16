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
		bool _agregar = false;


		public RegistroViewModel()
		{
			_registro = new Registro();
			registros = new ObservableCollection<Registro>();
		}

		public RegistroViewModel(Registro r)
		{
			_registro = r;
        }

        
        public string Nombre
		{
			get => _registro.nombre;
			set
			{
				if (this._registro.nombre != value)
				{
                    
                    _registro.nombre = value;
                    Agregar = string.IsNullOrEmpty(_registro.nombre) ? false : true;
                    OnPropertyChanged();
				}
			}
		}

    
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

		public bool Agregar
		{
			get => _agregar;
            set
            {
                
                    _agregar = value;
                    OnPropertyChanged();
                
            }
        }

		[RelayCommand]
		async void Add()
		{
			Registro contacto = new Registro();
			contacto = _registro;

			registros.Add(contacto);

			await Shell.Current.DisplayAlert("Alerta", "Se Agrego Correctamente", "Ok");

            //await Shell.Current.DisplayActionSheet("Compartir en ...?","Cancel",null,"Email","Twiter","Facebook");

			Nombre = string.Empty;

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