using CsvHelper.Configuration.Attributes;

namespace FakeEventGenerator.Domain.Models;

public class PreData
{
    [Index(0)]
    public int id { get; set; }

    [Index(1)]
    public string activity { get; set; }

    [Index(2)]
    public string bedroom_temperature { get; set; }

    [Index(3)]
    public string livingroom_light1 { get; set; }

    [Index(4)]
    public string livingroom_shutter1 { get; set; }

    [Index(5)]
    public string kitchen_oven_voltage { get; set; }

    [Index(6)]
    public string kitchen_cupboard2 { get; set; }

    [Index(7)]
    public string office_AC_setpoint { get; set; }

    [Index(8)]
    public string kitchen_sink_coldwater_instantaneous { get; set; }

    [Index(9)]
    public string kitchen_hood_voltage { get; set; }

    [Index(10)]
    public string bathroom_heater_base_setpoint { get; set; }

    [Index(11)]
    public string office_light { get; set; }

    [Index(12)]
    public string kitchen_cupboard4 { get; set; }

    [Index(13)]
    public string bedroom_heater1_command { get; set; }

    [Index(14)]
    public string livingroom_heater2_temperature { get; set; }

    [Index(15)]
    public string kitchen_CO2 { get; set; }

    [Index(16)]
    public string walkway_noise { get; set; }

    [Index(17)]
    public string livingroom_shutter2 { get; set; }

    [Index(18)]
    public string livingroom_heater1_temperature { get; set; }

    [Index(19)]
    public string walkway_switch1_top_right { get; set; }

    [Index(20)]
    public string livingroom_heater1_effective_setpoint { get; set; }

    [Index(21)]
    public string livingroom_switch2_top_left { get; set; }

    [Index(22)]
    public string kitchen_oven_partial_energy { get; set; }

    [Index(23)]
    public string kitchen_temperature { get; set; }

    [Index(24)]
    public string livingroom_heater2_effective_mode { get; set; }

    [Index(25)]
    public string bedroom_heater2_temperature { get; set; }

    [Index(26)]
    public string kitchen_fridge_total_energy { get; set; }

    [Index(27)]
    public string office_AC_mode { get; set; }

    [Index(28)]
    public string bedroom_light1 { get; set; }

    [Index(29)]
    public string bathroom_luminosity { get; set; }

    [Index(30)]
    public string bathroom_presence { get; set; }

    [Index(31)]
    public string bedroom_switch_bottom_left { get; set; }

    [Index(32)]
    public string bathroom_shower_hotwater_total { get; set; }

    [Index(33)]
    public string bedroom_light4 { get; set; }

    [Index(34)]
    public string bathroom_heater_command { get; set; }

    [Index(35)]
    public string office_tv_status { get; set; }

    [Index(36)]
    public string bathroom_humidity { get; set; }

    [Index(37)]
    public string bedroom_heater2_base_setpoint { get; set; }

    [Index(38)]
    public string kitchen_cooktop_partial_energy { get; set; }

    [Index(39)]
    public string bathroom_switch_top_right { get; set; }

    [Index(40)]
    public string bathroom_CO2 { get; set; }

    [Index(41)]
    public string office_heater_effective_mode { get; set; }

    [Index(42)]
    public string livingroom_switch1_top_right { get; set; }

    [Index(43)]
    public string bedroom_door { get; set; }

    [Index(44)]
    public string bathroom_sink_coldwater_instantaneous { get; set; }

    [Index(45)]
    public string bathroom_shower_door { get; set; }

    [Index(46)]
    public string kitchen_noise { get; set; }

    [Index(47)]
    public string walkway_light { get; set; }

    [Index(48)]
    public string bedroom_heater1_effective_setpoint { get; set; }

    [Index(49)]
    public string kitchen_dishwasher_power { get; set; }

    [Index(50)]
    public string livingroom_CO2 { get; set; }

    [Index(51)]
    public string walkway_switch1_bottom_right { get; set; }

    [Index(52)]
    public string kitchen_cooktop_current { get; set; }

    [Index(53)]
    public string walkway_switch2_top_right { get; set; }

    [Index(54)]
    public string walkway_switch2_bottom_right { get; set; }

    [Index(55)]
    public string kitchen_cooktop_voltage { get; set; }

    [Index(56)]
    public string bathroom_switch_bottom_left { get; set; }

    [Index(57)]
    public string livingroom_heater1_base_setpoint { get; set; }

    [Index(58)]
    public string bedroom_heater1_base_setpoint { get; set; }

    [Index(59)]
    public string livingroom_heater2_base_setpoint { get; set; }

    [Index(60)]
    public string kitchen_cupboard5 { get; set; }


    [Index(61)]
    public string entrance_noise { get; set; }

    [Index(62)]
    public string livingroom_shutter4 { get; set; }

    [Index(63)]
    public string bedroom_light2 { get; set; }

    [Index(64)]
    public string livingroom_shutter5 { get; set; }

    [Index(65)]
    public string bathroom_door { get; set; }

    [Index(66)]
    public string bedroom_switch_middle_left { get; set; }

    [Index(67)]
    public string livingroom_tv_plug_consumption { get; set; }

    [Index(68)]
    public string livingroom_window1 { get; set; }

    [Index(69)]
    public string bedroom_closet_door { get; set; }

    [Index(70)]
    public string kitchen_dishwasher_total_energy { get; set; }

    [Index(71)]
    public string toilet_light { get; set; }

    [Index(72)]
    public string kitchen_dishwasher_partial_energy { get; set; }

    [Index(73)]
    public string kitchen_hood_current { get; set; }

    [Index(74)]
    public string livingroom_switch1_bottom_left { get; set; }

    [Index(75)]
    public string entrance_door { get; set; }

    [Index(76)]
    public string livingroom_light2 { get; set; }

    [Index(77)]
    public string staircase_switch_right { get; set; }

    [Index(78)]
    public string kitchen_sink_coldwater_total { get; set; }

    [Index(79)]
    public string bathroom_light2 { get; set; }

    [Index(80)]
    public string livingroom_heater1_command { get; set; }

    [Index(81)]
    public string kitchen_switch_top_left { get; set; }

    [Index(82)]
    public string livingroom_switch1_top_left { get; set; }

    [Index(83)]
    public string bedroom_switch_middle_right { get; set; }

    [Index(84)]
    public string livingroom_heater2_command { get; set; }

    [Index(85)]
    public string toilet_switch_left { get; set; }

    [Index(86)]
    public string bedroom_switch_bottom_right { get; set; }

    [Index(87)]
    public string bedroom_switch_top_left { get; set; }

    [Index(88)]
    public string bedroom_heater2_effective_mode { get; set; }

    [Index(89)]
    public string livingroom_presence_couch { get; set; }

    [Index(90)]
    public string office_window { get; set; }

    [Index(91)]
    public string kitchen_hood_partial_energy { get; set; }

    [Index(92)]
    public string kitchen_fridge_partial_energy { get; set; }

    [Index(93)]
    public string kitchen_fridge_current { get; set; }

    [Index(94)]
    public string bedroom_drawer1 { get; set; }

    [Index(95)]
    public string kitchen_presence { get; set; }

    [Index(96)]
    public string office_tv_plug_consumption { get; set; }

    [Index(97)]
    public string bedroom_shutter1 { get; set; }

    [Index(98)]
    public string staircase_switch_left { get; set; }

    [Index(99)]
    public string kitchen_cooktop_total_energy { get; set; }

    [Index(100)]
    public string walkway_switch2_bottom_left { get; set; }

    [Index(101)]
    public string entrance_heater_command { get; set; }

    [Index(102)]
    public string bathroom_heater_temperature { get; set; }

    [Index(103)]
    public string kitchen_switch_top_right { get; set; }

    [Index(104)]
    public string livingroom_presence_table { get; set; }

    [Index(105)]
    public string kitchen_sink_hotwater_total { get; set; }

    [Index(106)]
    public string kitchen_cooktop_power { get; set; }

    [Index(107)]
    public string office_switch_left { get; set; }

    [Index(108)]
    public string kitchen_hood_power { get; set; }

    [Index(109)]
    public string livingroom_shutter3 { get; set; }

    [Index(110)]
    public string walkway_switch1_top_left { get; set; }

    [Index(111)]
    public string livingroom_heater2_effective_setpoint { get; set; }

    [Index(112)]
    public string kitchen_oven_current { get; set; }

    [Index(113)]
    public string entrance_heater_base_setpoint { get; set; }

    [Index(114)]
    public string livingroom_switch2_top_right { get; set; }

    [Index(115)]
    public string bedroom_CO2 { get; set; }

    [Index(116)]
    public string kitchen_sink_hotwater_instantaneous { get; set; }

    [Index(117)]
    public string bathroom_light1 { get; set; }

    [Index(118)]
    public string staircase_light { get; set; }

    [Index(119)]
    public string bedroom_AC_setpoint { get; set; }

    [Index(120)]
    public string office_door { get; set; }

    [Index(121)]
    public string kitchen_hood_total_energy { get; set; }

    [Index(122)]
    public string toilet_coldwater_instantaneous { get; set; }

    [Index(123)]
    public string entrance_light1 { get; set; }

    [Index(124)]
    public string bedroom_humidity { get; set; }

    [Index(125)]
    public string kitchen_light2 { get; set; }

    [Index(126)]
    public string bathroom_shower_coldwater_total { get; set; }

    [Index(127)]
    public string kitchen_fridge_voltage { get; set; }

    [Index(128)]
    public string kitchen_fridge_door { get; set; }

    [Index(129)]
    public string entrance_heater_effective_mode { get; set; }

    [Index(130)]
    public string livingroom_tv_status { get; set; }

    [Index(131)]
    public string bedroom_heater2_command { get; set; }

    [Index(132)]
    public string kitchen_switch_bottom_right { get; set; }

    [Index(133)]
    public string office_shutter { get; set; }

    [Index(134)]
    public string toilet_coldwater_total { get; set; }

    [Index(135)]
    public string kitchen_dishwasher_voltage { get; set; }

    [Index(136)]
    public string bathroom_sink_hotwater_instantaneous { get; set; }

    [Index(137)]
    public string kitchen_washingmachine_voltage { get; set; }

    [Index(138)]
    public string bedroom_luminosity { get; set; }

    [Index(139)]
    public string bedroom_switch_top_right { get; set; }

    [Index(140)]
    public string walkway_switch2_top_left { get; set; }

    [Index(141)]
    public string office_heater_command { get; set; }

    [Index(142)]
    public string livingroom_couch_plug_consumption { get; set; }

    [Index(143)]
    public string bedroom_heater2_effective_setpoint { get; set; }

    [Index(144)]
    public string office_heater_effective_setpoint { get; set; }

    [Index(145)]
    public string bedroom_bed_pressure { get; set; }

    [Index(146)]
    public string kitchen_light1 { get; set; }

    [Index(147)]
    public string office_switch_right { get; set; }

    [Index(148)]
    public string toilet_switch_right { get; set; }

    [Index(149)]
    public string kitchen_oven_power { get; set; }

    [Index(150)]
    public string office_noise { get; set; }

    [Index(151)]
    public string bathroom_shower_hotwater_instantaneous { get; set; }

    [Index(152)]
    public string office_switch_middle { get; set; }

    [Index(153)]
    public string kitchen_oven_total_energy { get; set; }

    [Index(154)]
    public string livingroom_temperature { get; set; }

    [Index(155)]
    public string kitchen_humidity { get; set; }

    [Index(156)]
    public string bathroom_switch_top_left { get; set; }

    [Index(157)]
    public string office_luminosity { get; set; }

    [Index(158)]
    public string kitchen_washingmachine_partial_energy { get; set; }

    [Index(159)]
    public string livingroom_humidity { get; set; }

    [Index(160)]
    public string bathroom_heater_effective_setpoint { get; set; }

    [Index(161)]
    public string kitchen_switch_bottom_left { get; set; }

    [Index(162)]
    public string bedroom_shutter2 { get; set; }

    [Index(163)]
    public string bathroom_sink_coldwater_total { get; set; }

    [Index(164)]
    public string livingroom_table_luminosity { get; set; }

    [Index(165)]
    public string kitchen_dishwasher_current { get; set; }

    [Index(166)]
    public string office_heater_temperature { get; set; }

    [Index(167)]
    public string kitchen_washingmachine_current { get; set; }

    [Index(168)]
    public string kitchen_washingmachine_power { get; set; }

    [Index(169)]
    public string kitchen_luminosity { get; set; }

    [Index(170)]
    public string bedroom_presence { get; set; }

    [Index(171)]
    public string kitchen_cupboard1 { get; set; }

    [Index(172)]
    public string kitchen_fridge_power { get; set; }

    [Index(173)]
    public string kitchen_cupboard3 { get; set; }

    [Index(174)]
    public string bedroom_drawer2 { get; set; }

    [Index(175)]
    public string walkway_switch1_bottom_left { get; set; }

    [Index(176)]
    public string livingroom_table_noise { get; set; }

    [Index(177)]
    public string livingroom_heater1_effective_mode { get; set; }

    [Index(178)]
    public string bedroom_light3 { get; set; }

    [Index(179)]
    public string office_desk_plug_consumption { get; set; }

    [Index(180)]
    public string kitchen_washingmachine_total_energy { get; set; }

    [Index(181)]
    public string bathroom_shower_coldwater_instantaneous { get; set; }

    [Index(182)]
    public string livingroom_AC_setpoint { get; set; }

    [Index(183)]
    public string bedroom_noise { get; set; }

    [Index(184)]
    public string bedroom_heater1_effective_mode { get; set; }

    [Index(185)]
    public string entrance_switch_left { get; set; }

    [Index(186)]
    public string office_presence { get; set; }

    [Index(187)]
    public string bathroom_switch_bottom_right { get; set; }

    [Index(188)]
    public string office_heater_base_setpoint { get; set; }

    [Index(189)]
    public string livingroom_couch_noise { get; set; }

    [Index(190)]
    public string bedroom_heater1_temperature { get; set; }

    [Index(191)]
    public string livingroom_table_plug_consumption { get; set; }

    [Index(192)]
    public string entrance_heater_effective_setpoint { get; set; }

    [Index(193)]
    public string livingroom_luminosity { get; set; }

    [Index(194)]
    public string bathroom_sink_hotwater_total { get; set; }

    [Index(195)]
    public string bathroom_heater_effective_mode { get; set; }

    [Index(196)]
    public string entrance_heater_temperature { get; set; }

    [Index(197)]
    public string bathroom_temperature { get; set; }
}

