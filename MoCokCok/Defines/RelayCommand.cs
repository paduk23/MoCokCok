using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/// <summary>
/// 참고 출처 : https://youtu.be/OTMyi2XrVyw
/// ICommand는 2가지 메서드(Execute, CanExcute)와 1개의 이벤트(CanExecuteChanged)를 제공 한다.
/// 
/// Execute : 실제 처리 해야 하는 로직
/// 
/// CanExcute : Execute의 실행 여부 결정 (false 시 Execute의 호출 X, 기능 작동 x) 
/// => 즉 명령 여부를 확인하여 WPF에 의해 호출. 대부분 UI상호 작용에 발생
/// => 사용자 명령의 경우 대부분 호출이 안되므로 이벤트(CanExecuteChanged)를 발생시켜 CommandManager의 RequerySuggested 이벤트에 연결 한다.
/// </summary>

namespace MoCokCok.Defines
{
	public class RelayCommand : ICommand
	{
		Func<object, bool> canExecute;
		Action<object> executeAction;

		public RelayCommand(Action<object> executeAction) : this(executeAction, null) { }

		public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
		{
			this.executeAction = executeAction ?? throw new ArgumentNullException("Execute Action was null for ICommanding Operation.");
			this.canExecute = canExecute;
		}


		/// <summary>
		/// CommandManager.RequerySuggested 이벤트가 호출될 때마다 실행
		/// 즉, CanExecuteChanged 이벤트가 호출될 때마다 실행
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			if (parameter?.ToString().Length == 0)
			{
				return false;
			}
			return canExecute == null || canExecute.Invoke(parameter);
		}

		public void Execute(object parameter)
		{
			executeAction.Invoke(parameter);
		}

		/// <summary>
		/// CanExecuteChanged 이벤트는 해당 ICommand에 바인딩 된
		/// 모든 명령 소스(예 : Button 또는 MenuItem)에
		/// CanExecute에 의해 반환 된 값이 변경 되었음을 알린다.
		/// 
		/// 커맨드 소스는 일반적으로 상태를 적절히 업데이트해야 하는데
		/// 예를 들면 CanExecute()가 false를 반환하면 버튼이 비활성화 된다).
		/// 
		/// CommandManager.RequerySuggested 이벤트는 CommandManager가 명령 실행에
		/// 영향을 줄 수있는 변경 사항이 있다고 생각할 때마다 발생하며 이때마다
		/// CanExecute가 호출된다.
		/// 
		/// 예를 들어, 이는 포커스의 변화 일 수 있는데. 이 이벤트가 많이 발생한다.
		/// 따라서 본질적으로 이 코드의 역할은 CommandManager가 명령 실행 기능이 변경되었다고 생각할 때마다(실제로 변경되지 않은 경우에도) CanExecuteChanged를 발생시키는 것이다.
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}
