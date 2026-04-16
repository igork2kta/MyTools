using MyTools.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class HotkeyManager : IDisposable
{
    private const int WM_HOTKEY = 0x0312;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [Flags]
    private enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    private readonly IntPtr _handle;
    private readonly Dictionary<int, ShortcutKey> _registered = new();
    private int _currentId = 0;

    public HotkeyManager(IntPtr handle)
    {
        _handle = handle;
    }

    // =========================
    // REGISTRAR LISTA
    // =========================
    public void RegisterShortcuts(List<ShortcutKey> shortcuts)
    {
        foreach (var shortcut in shortcuts)
        {
            if (!shortcut.Active)
                continue;

            RegisterShortcut(shortcut);
        }
    }

    // =========================
    // REGISTRAR INDIVIDUAL
    // =========================
    public void RegisterShortcut(ShortcutKey shortcut)
    {
        _currentId++;

        uint modifiers = 0;
        if (shortcut.Control) modifiers |= (uint)KeyModifiers.Control;
        if (shortcut.Alt) modifiers |= (uint)KeyModifiers.Alt;
        if (shortcut.Shift) modifiers |= (uint)KeyModifiers.Shift;

        bool success = RegisterHotKey(_handle, _currentId, modifiers, (uint)shortcut.Key);

        if (!success)
        {
            // Pode falhar se já estiver em uso no sistema
            // Você pode logar isso se quiser
            return;
        }

        _registered[_currentId] = shortcut;
    }

    // =========================
    // PROCESSAR MENSAGEM
    // =========================
    public void ProcessHotkey(Message m)
    {
        //Console.WriteLine($"MSG: {m.Msg}");

        if (m.Msg != WM_HOTKEY)
            return;

        int id = m.WParam.ToInt32();

        if (_registered.TryGetValue(id, out var shortcut))
        {
            shortcut.EventHandler?.Invoke(null, EventArgs.Empty);
        }
    }

    // =========================
    // LIMPAR
    // =========================
    public void UnregisterAll()
    {
        foreach (var id in _registered.Keys)
        {
            UnregisterHotKey(_handle, id);
        }

        _registered.Clear();
    }

    public void Dispose()
    {
        UnregisterAll();
    }
}