package logger;

// Sin patrones de diseño
// public class Consolelogger {
//    private static int counter = 1;
//
//    public static void debug(String message) {
//        System.out.println("[debug][" + counter++ + "] - " + message);
//    }
//}

public class Consolelogger {

    private static Consolelogger instance;
    private int counter;

    private Consolelogger() {
        counter = 0;
    }

    public static Consolelogger getInstance() {
        if (instance == null) {
            instance = new Consolelogger();
        }
        return instance;
    }

    public void debug(String message) {
        counter++;
        System.out.println("[debug][" + counter + "] - " + message);
    }
}
