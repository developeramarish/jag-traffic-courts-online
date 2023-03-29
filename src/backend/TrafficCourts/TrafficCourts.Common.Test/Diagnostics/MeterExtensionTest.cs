﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficCourts.Common.Diagnostics;
using Xunit;

namespace TrafficCourts.Common.Test.Diagnostics;

public class MeterExtensionTest
{
    [Fact]
    public void should_be_able_to_create_timer()
    {
        var meter = new Meter("meter");

        Timer timer = meter.CreateTimer("example-timer", "Example");
        Assert.NotNull(timer);
    }
}

public class TimerTest
{ 
    [Fact]
    public void create_timer()
    {
        var meter = new Meter("meter");

        Timer timer = new Timer(meter, "timer", "ms", "A timer");
        using var mark1 = timer.Start();

        var tags = new TagList
        {
            { "name", "value" }
        };
        using var mark2 = timer.Start(tags);
    }
}

