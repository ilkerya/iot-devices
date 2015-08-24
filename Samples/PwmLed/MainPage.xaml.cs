﻿// Copyright (c) Microsoft. All rights reserved.
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.IoT.Devices.Lights;
using Microsoft.IoT.Devices.Pwm;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PwmLed
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Member Variables
        private RgbLed led;
        #endregion // Member Variables

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Start GPIO
            var gpioController = GpioController.GetDefault();

            // Create PWM manager
            var pwmManager = new PwmProviderManager();

            //var p = new PCA9685();
            //await p.EnsureInitializedAsync();
            // Add PWM chips
            // pwmManager.Providers.Add(p);
            pwmManager.Providers.Add(new PCA9685());

            // Get the well-known controller collection back
            var pwmControllers = await pwmManager.GetControllersAsync();

            // Using the first PWM controller
            var controller = pwmControllers[0];

            // Set desired frequency
            controller.SetDesiredFrequency(50);

            // Create light sensor
            var led = new RgbLed()
            {
                RedPin = controller.OpenPin(0),
                GreenPin = controller.OpenPin(1),
                BluePin = controller.OpenPin(2),
            };

            led.Color = Colors.Orange;
        }
    }
}